using AutoScrewing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoScrewing
{
    public partial class DashboardForm : Form
    {
        private DashboardModel _dashboardmodel = new DashboardModel();
        SerialPort _client = new SerialPort();
        string baseAddress = "COM4";
        Barrier barrier = new Barrier(2);
        CancellationTokenSource cts = new CancellationTokenSource();
        private DashboardModel DashboardModel { get => _dashboardmodel;  set {
                _dashboardmodel = value;
                SetDashbaordControl(_dashboardmodel);        
            } 
        }
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            //DashboardModel data = new DashboardModel()
            //{
            //    DeviceID = "001",
            //    Thread = 9,
            //    Time = new TimeSpan(0, 0, 0, 2, 7210),
            //    Torque = 0.802M,
            //    ScrewCount = 1,
            //    ScrewTotal = 1,
            //    ProgramSeq = "P1\t1",
            //    OK=5,
            //    NG=52,
            //    OKALL=5,
            //    Job=1,
            //    Seq=1,
            //    TighteningStatus = "3NG-F"
            //};
            //DashboardModel = data;
            _client = BuildPort();
            Task.Run(()=>ReadIncomingData());
        }
        
        private async void SetDashbaordControl(DashboardModel model)
        {
            await InvokeAsync(() =>
            {
                TighteningStatusLabel.Text = model.TighteningStatus;
                TorqueLabel.Text = $"{model.Torque} {model.TorqueType}";
                ScrewCountLabel.Text = $"{model.ScrewCount} of {model.ScrewTotal}";
                TimeLabel.Text = string.Format("{0:00000} Sec", model.Time.TotalSeconds);
                ProgramSeqLabel.Text = model.ProgramSeq;
                ThreadLabel.Text = string.Format("{0:00000}",model.Thread);
                DeviceIDLabel.Text = model.DeviceID;
                OkAllLabel.Text = model.StatusCount.OKALL.ToString();
                OkCountLabel.Text = model.StatusCount.OK.ToString();
                NgCountLabel.Text = model.StatusCount.NG.ToString();
                jobLabel.Text = model.JobSeq.Job.ToString();
                SeqLabel.Text=  model.JobSeq.Seq.ToString();

            });
        }

        SerialPort BuildPort()
        {
            SerialPort sp = new SerialPort(baseAddress, 115200, Parity.None, 8, StopBits.One);
            sp.NewLine = "\r\n";
            return sp;
        }
        string GetCommand(string cmd)
        {


            DateTime dt = DateTime.Now;
            int checksum = dt.Year + dt.Month + dt.Day + dt.Hour + dt.Month + dt.Second;
            string command = $"{{{cmd},{dt.Year},{dt.Month},{dt.Day},{dt.Hour},{dt.Minute},{dt.Second},{checksum},{checksum + 5438},1,1,}}\n\r";
            return command;
        }
        private async Task ReadIncomingData()
        {
            while (true)
            {

                using (_client)
                {
                    _client.Open();
                    _client.ReadTimeout = 1000;
                    try
                    {
                        if (cts.IsCancellationRequested)
                        {
                            barrier.SignalAndWait();
                            continue;
                        }
                        string cmd = GetCommand("DATA100");
                        byte[] buffer = Encoding.ASCII.GetBytes(cmd);
                        _client.Write(buffer, 0, buffer.Length);
                        await Task.Delay(1000);
                        byte[] rd = new byte[8];
                        string text = _client.ReadLine();
                        string[] data = text.Split(',');
                        if (data.Length < 28 || !data.Contains("DATA100"))
                            throw new Exception("Invalid Data");
                        DashboardModel model = new DashboardModel();
                        //                        string tt =
                        //"{DATA100,2025,06,01,16,56,50,2154,7592,4,001,T02VE00007__________,C14Z-E00812_________,0000000017,01,01,01,4Nm___,01,000.00000,1,0021.4500,0139.6,01/01,1,3NG-F,9,}";//28
                        model.ScrewTotal = int.Parse(data[23].Split('/')[1]);
                        model.ScrewCount = int.Parse(data[23].Split('/')[0]);
                        model.DeviceID = data[10];
                        model.TighteningStatus = data[25];
                        model.Thread = decimal.Parse(data[22]);
                        model.Time = TimeSpan.Parse(data[21]);
                        model.Torque = decimal.Parse(data[19]);
                        model.TorqueType = data[18].Replace("_", "");
                        DashboardModel = model;

                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                        string cmd = GetCommand("CMD100");
                        byte[] buffer = Encoding.ASCII.GetBytes(cmd);

                        if (!_client.IsOpen)
                            _client.Open();
                        _client.Write(buffer, 0, buffer.Length);
                        await Task.Delay(1000);

                    }
                }
            }
        }
    }
}
