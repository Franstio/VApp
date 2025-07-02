using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using AutoScrewing.Dialogue;
using AutoScrewing.Lib;
using AutoScrewing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoScrewing
{
    public partial class DashboardForm : Form, DashboardForm.IDashboardOngoingItems
    {
        private TransactionRepository TransactionRepository = new TransactionRepository();
        private KilewController kilewController = new KilewController();
        private PLCController plcController = new PLCController();
        private DashboardModel _dashboardmodel = new DashboardModel();
        private MESHController meshController = new MESHController();
        SemaphoreSlim semaphore = new SemaphoreSlim(1);
        Queue<OngoingItemModel>
            ScrewingQueue = new Queue<OngoingItemModel>(),
            LaserQueue = new Queue<OngoingItemModel>(),
            CameraQueue = new Queue<OngoingItemModel>();

        public async Task<List<OngoingItemModel>> GetOngoingItems()
        {
            await semaphore.WaitAsync();
            List<Queue<OngoingItemModel>> a = [ScrewingQueue, LaserQueue, CameraQueue];
            semaphore.Release();
            return a.SelectMany(x => x).ToList();
        }

        private List<DashboardModel> listRunning = new List<DashboardModel>();
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
            //            textBox1.Text = "test";
        }

        private async void SetDashbaordControl(DashboardModel model)
        {
            await InvokeAsync(() =>
            {
                torqueLabel.Text = $"{model.Torque} {model.TorqueType}";
                screwingResultLabel.Text = model.TighteningStatus;
                screwingTimeLabel.Text = model.Time;
                laserResultLabel.Text = model.LaserStatus ? "OK" : "NG";
                cameraResultLabel.Text = model.CameraStatus ? "OK" : "NG";
            });
        }
        private async Task<bool> ReadCamera()
        {
            var startTime = DateTime.Now;
            PLCController.PLCItem[] cmd = [
                new PLCController.PLCItem("RD", "MR310", -1, "Read For Reading Camera NG"),
                new PLCController.PLCItem("RD", "MR311", -1, "Read For Reading Camera OK")
            ];
            List<Task<string>> task = [
                Task.Run<string>(async () => await plcController.Send(cmd[0])),
                Task.Run<string>(async () => await plcController.Send(cmd[1]))
            ];
            await Task.WhenAll(task);
            string OK = await task[1], NG = await task[0];
            bool result = false;
            if (NG == "0")
            {
                result = (OK == "1");

            }
            else if (OK == "0")
            {
                result = !(NG == "1");
            }
            if (CameraQueue.Count > 1)
            {
                await semaphore.WaitAsync();
                var item = CameraQueue.Dequeue();
                item.CameraStartTime = startTime;
                item.CameraEndTime = DateTime.Now;
                if ((OK != "0" && OK != "0") && (NG != "0" && NG != "1"))
                {
                    item.AddError("Camera");
                }
                item.CameraResult = result;
                item.CurrentStatus = "Completed";
                await TransactionRepository.CreateTransaction(item);
                semaphore.Release();
            }
            return result;
        }
        private async Task ReadIncomingData()
        {
            while (true)
            {
                try
                {
                    Task<DashboardModel> screwingTask = Task.Run(async () => await ReadingScrewing());
                    Task<bool> laserTask = Task.Run(async () => await ReadingLaser());
                    Task<bool> cameraTask = Task.Run(async () => await ReadCamera());
                    await Task.WhenAll(screwingTask, laserTask);
                    DashboardModel model = await screwingTask;
                    model.LaserStatus = await laserTask;
                    model.CameraStatus = await cameraTask;
                    DashboardModel = model;
                }
                catch (Exception ex)
                {
                    LogModel log = new LogModel("Read Incoming Data", "ReadIncomingData function", "Exception handler for handling unexpected error in loop and continue the loop", "Failed");
                    log.Result = $"{ex.Message} | {ex.StackTrace}";
                    LogRepository logrepo = new LogRepository();
                    await logrepo.RecordLog(log);
                }
            }
        }
        private async Task<bool> ReadingLaser()
        {
            PLCController.PLCItem[] cmd = [
                new PLCController.PLCItem("RD", "MR308", -1, "Read For Reading Laser NG"),
                new PLCController.PLCItem("RD", "MR309", -1, "Read For Reading Laser OK")
            ];
            List<Task<string>> task = [
                Task.Run<string>(async () => await plcController.Send(cmd[0])),
                Task.Run<string>(async () => await plcController.Send(cmd[1]))
            ];
            var startTime = DateTime.Now;
            await Task.WhenAll(task);
            string OK = await task[1], NG = await task[0];
            bool result = false;
            if (NG == "0")
            {
                result = (OK == "1");

            }
            else if (OK == "0")
            {
                result = !(NG == "1");
            }
            if (LaserQueue.Count > 1)
            {

                await semaphore.WaitAsync();
                var item = LaserQueue.Dequeue();
                if ((OK != "0" && OK != "0") && (NG != "0" && NG != "1"))
                {
                    item.AddError("Laser");
                }
                item.LaserResult = result;
                item.LaserStartTime = startTime;
                item.LaserEndTime = DateTime.Now;
                item.CurrentStatus = "Camera";
                CameraQueue.Enqueue(item);
                semaphore.Release();
            }
            return result;
        }
        private async Task<DashboardModel> ReadingScrewing()
        {
            var startTime = DateTime.Now;
            string res = await kilewController.Send("DATA100");
            string[] data = res.Split(",");
            if (data.Length < 28)
                throw new Exception("Invalid Data");
            DashboardModel model = new DashboardModel();
            if (data[0].Contains("REQ100"))
            {
                res = await kilewController.Send("CMD100");
            }
            //                        string tt =
            //"{DATA100,2025,06,01,16,56,50,2154,7592,4,001,T02VE00007__________,C14Z-E00812_________,0000000017,01,01,01,4Nm___,01,000.00000,1,0021.4500,0139.6,01/01,1,3NG-F,9,}";//28
            if (data[0].Replace("{", "").Contains("DATA100"))
            {
                model.ScrewTotal = int.Parse(data[23].Split('/')[1]);
                model.ScrewCount = int.Parse(data[23].Split('/')[0]);
                model.DeviceID = data[10];
                model.TighteningStatus = data[25];
                model.Thread = decimal.Parse(data[22]);
                model.Time = data[21];
                model.Torque = decimal.Parse(data[19]);
                model.TorqueType = data[18].Replace("_", "");

                if (ScrewingQueue.Count > 0)
                {

                    await semaphore.WaitAsync();
                    var item = ScrewingQueue.Dequeue();
                    item.Torque = model.Torque;
                    item.ScrewingResult = model.TighteningStatus.Contains("OK");
                    item.ScrewingTime = model.Time;
                    item.ThreadCount = model.Thread;
                    item.ScrewStartTime = startTime;
                    item.ScrewEndTime = DateTime.Now;
                    item.CurrentStatus = "Lasering";
                    LaserQueue.Enqueue(item);
                    semaphore.Release();
                }
            }
            else if (data[0].Replace("{", "").Contains("REQ100"))
            {
                model.ScrewTotal = int.Parse(data[26].Split('/')[1]);
                model.ScrewCount = int.Parse(data[26].Split('/')[0]);
                model.DeviceID = data[11];
                model.TighteningStatus = "-";
                model.Thread = 0;
                model.Time = TimeSpan.Zero.ToString();
                model.Torque = 0;
            }
            return model;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("dd-MMM-yy HH:mm:ss");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (scan1Box.Text == "Scan 1")
                scan1Box.Text = string.Empty;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(scan1Box.Text))
                scan1Box.Text = "Scan 1";
        }

        private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            string scan = scan1Box.Text;
            string scan2 = scan2Box.Text;
            if (scan == "") return;
            else if (scan == Settings1.Default.RunningPass)
            {
                new RunningQueue(this).Show();
                scan1Box.Clear();
                return;
            }
            if (string.IsNullOrEmpty(scan2Box.Text) || scan2 == "Scan 2")
            {
                scan2Box.Focus();
            }
            else
            {
                scan1Box.Clear();
                scan2Box.Clear();
                scan = scan.Replace("SCAN 1", "");
                scan2 = scan2.Replace("SCAN 2", "");
                await meshController.Tracking(scan);
                await Task.Delay(1000);
                ScrewingQueue.Enqueue(new OngoingItemModel() { Scan_ID = scan, Scan_ID2 = scan2, StartTime = DateTime.Now, CurrentStatus = "Screwing" });
            }
        }

        private  void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new LoginForm())
            {
                var result = frm.ShowDialog();
                var usr = frm.GetLogin();
                if (result == DialogResult.OK && usr != null)
                {
                    using (var cfg = new ConfigForm(usr))
                    {
                        cfg.ShowDialog();
                    }
                }
            }
        }

        private async void scan2Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            string scan = scan1Box.Text;
            string scan2 = scan2Box.Text;
            if (scan == "") return;
            else if (scan2 == Settings1.Default.RunningPass)
            {
                new RunningQueue(this).Show();
                scan2Box.Clear();
                return;
            }
            if (string.IsNullOrEmpty(scan1Box.Text) || scan == "Scan 1")
            {
                scan1Box.Focus();
            }
            else
            {
                scan1Box.Clear();
                scan2Box.Clear();
                scan = scan.Replace("SCAN 1", "");
                scan2 = scan2.Replace("SCAN 2", "");
                await meshController.Tracking(scan);
                await Task.Delay(1000);
                ScrewingQueue.Enqueue(new OngoingItemModel() { Scan_ID = scan, Scan_ID2 = scan2, StartTime = DateTime.Now, CurrentStatus = "Screwing" });
            }
        }

        private void scan2Box_Enter(object sender, EventArgs e)
        {
            if (scan2Box.Text == "Scan 2")
                scan2Box.Text = string.Empty;
        }

        private void scan2Box_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(scan2Box.Text))
                scan2Box.Text = "Scan 2";
        }

        public interface IDashboardOngoingItems
        {
            Task<List<OngoingItemModel>> GetOngoingItems();
        }
    }
}
