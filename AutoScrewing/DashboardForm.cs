using AutoScrewing.Database.Repository;
using AutoScrewing.Lib;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoScrewing
{
    public partial class DashboardForm : Form
    {
        private TransactionRepository TransactionRepository = new TransactionRepository();
        private KilewController kilewController = new KilewController();
        private PLCController plcController = new PLCController();
        private DashboardModel _dashboardmodel = new DashboardModel();
        Barrier barrier = new Barrier(2);
        CancellationTokenSource cts = new CancellationTokenSource();
        private DashboardModel DashboardModel
        {
            get => _dashboardmodel; set
            {
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
            Task.Run(() => ReadIncomingData());
        }

        private async void SetDashbaordControl(DashboardModel model)
        {
            await InvokeAsync(() =>
            {
                torqueLabel.Text = $"{model.Torque} {model.TorqueType}";
                screwingResultLabel.Text = model.TighteningStatus;
                laserResultLabel.Text = model.LaserStatus ? "OK" : "NG";
            });
        }
        private async Task ReadIncomingData()
        {
            while (true)
            {

                try
                {
                    if (cts.IsCancellationRequested)
                    {
                        barrier.SignalAndWait();
                        continue;
                    }
                    Task<string[]> screwingTask = Task.Run(async () => await ReadingScrewing());
                    Task<bool> laserTask = Task.Run(async () => await ReadingLaser());
                    await Task.WhenAll(screwingTask, laserTask);
                    DashboardModel model = new DashboardModel();
                    string[] data = await screwingTask;
                    //                        string tt =
                    //"{DATA100,2025,06,01,16,56,50,2154,7592,4,001,T02VE00007__________,C14Z-E00812_________,0000000017,01,01,01,4Nm___,01,000.00000,1,0021.4500,0139.6,01/01,1,3NG-F,9,}";//28
                    if (data[0].Replace("{", "").Contains("DATA100"))
                    {
                        model.ScrewTotal = int.Parse(data[23].Split('/')[1]);
                        model.ScrewCount = int.Parse(data[23].Split('/')[0]);
                        model.DeviceID = data[10];
                        model.TighteningStatus = data[25];
                        model.Thread = decimal.Parse(data[22]);
                        model.Time = TimeSpan.Parse(data[21]);
                        model.Torque = decimal.Parse(data[19]);
                        model.TorqueType = data[18].Replace("_", "");
                    }
                    else if (data[0].Replace("{", "").Contains("REQ100"))
                    {
                        model.ScrewTotal = int.Parse(data[26].Split('/')[1]);
                        model.ScrewCount = int.Parse(data[26].Split('/')[0]);
                        model.DeviceID = data[11];
                        model.TighteningStatus = "-";
                        model.Thread = 0;
                        model.Time = TimeSpan.Zero;
                        model.Torque = 0;
                    }
                    model.LaserStatus = await laserTask;
                    DashboardModel = model;

                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    string cmd = await kilewController.Send("CMD100");
                    await Task.Delay(1000);

                }

            }
        }
        private async Task<bool> ReadingLaser()
        {
            PLCController.PLCItem[] cmd = [
                new PLCController.PLCItem("RD", "MR308", -1, "Read For Reading Laser NG"),
                new PLCController.PLCItem("RD", "MR308", -1, "Read For Reading Laser OK")
            ];
            Task<string>[] task = new Task<string>[2];
            for (int i = 0;i<cmd.Length;i++)
            {
                task[i] = Task.Run<string>(async () => await plcController.Send(cmd[i]));
            }
            await Task.WhenAll(task);
            if (await task[1] == "1")
                return true;
            else if (await task[0] == "1")
                return false;
            return false;
        }
        private async Task<string[]> ReadingScrewing()
        {
            string res = await kilewController.Send("DATA100");
            string[] data = res.Split(",");
            if (data.Length < 28)
                throw new Exception("Invalid Data");
            return data;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToUniversalTime().ToString();
        }
    }
}
