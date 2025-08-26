using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using AutoScrewing.Dialogue;
using AutoScrewing.Lib;
using AutoScrewing.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Label = System.Windows.Forms.Label;

namespace AutoScrewing
{
    public partial class DashboardForm : Form, DashboardForm.IDashboardOngoingItems, IOStatusForm.IOStatusAPI, QueueManual.IQueueManual
    {
        private TransactionRepository TransactionRepository = new TransactionRepository();
        private MESHController meshController;
        private KilewController kilewController;
        private PLCController plcController;
        private DashboardModel _dashboardmodel = new DashboardModel();
        private bool meshSend = false;
        private bool runTrigger = false;
        private EmergencyDialogue msgDialogue = new EmergencyDialogue();
        private LogRepository logRepository = new LogRepository();
        private string CHECKSUM_SCREWING = "", NEW_CHECKSUM_SCREWING = "";
//        SemaphoreSlim semaphore = new SemaphoreSlim(1);
        Queue<OngoingItemModel>
            StandbyQueue = new Queue<OngoingItemModel>(),
            ScrewingQueue = new Queue<OngoingItemModel>(),
            LaserQueue = new Queue<OngoingItemModel>(),
            CameraQueue = new Queue<OngoingItemModel>(),
            FinalQueue = new Queue<OngoingItemModel>(),
            RegisteredItem = new Queue<OngoingItemModel>();
        public Task<List<OngoingItemModel>> GetOngoingItems()
        {
            List<Queue<OngoingItemModel>> a = [StandbyQueue,ScrewingQueue, LaserQueue, CameraQueue, FinalQueue];
            try
            {
                return Task.FromResult(a.SelectMany(x => x).OrderByDescending(x => x.TransactionTime).ToList());
            }
            catch
            {
                return Task.FromResult<List<OngoingItemModel>>([]);
            }
        }
        private async Task LoadData()
        {
            var list = await GetOngoingItems();
            var finishedList = RegisteredItem.ToList();
            List<OngoingItemModel> combine = [.. list, .. finishedList.TakeLast(4 - list.Count)];
            var data = combine.OrderByDescending(x => x.StartTime is null ? DateTime.MaxValue : x.StartTime).Select(x => new object[] { x.Scan_ID, x.Scan_ID2, $"{(x.isScrewingCompleted ? x.TighteningStatus : "-")} {x.Torque}", x.isLaseringCompleted ? (x.LaserResult ? "OK" : "NG") : "-", x.isCameraCompleted ? (x.CameraResult ? "OK" : "NG") : "-", x.isScrewingCompleted && x.isLaseringCompleted && x.isCameraCompleted ? x.FinalResult : "-" }).ToArray();
            //    var transactionData = (await TransactionRepository.GetTransaction(1)).Select(x => new object[] { x.Scan_ID, x.Scan_ID2, $"{x.TighteningStatus} {x.Torque}", x.LaserResult ? "OK" : "NG", x.CameraResult ? "OK" : "NG", x.FinalResult });
            await InvokeAsync(() =>
            {
                dataGridView1.Rows.Clear();
                if (data.Length < 1)
                    return;
                int finalResultColumnIndex = data[0].Length-1;
                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(item);
                    var rowCell = dataGridView1.Rows[^1];
                    if (item[finalResultColumnIndex] is not null && item[finalResultColumnIndex]?.ToString() != "-")
                    {
                        rowCell.Cells[finalResultColumnIndex].Style.BackColor = item[finalResultColumnIndex].ToString() == "NG" ? ColorTranslator.FromHtml("#EF4444") : ColorTranslator.FromHtml("#10B981");
                        rowCell.Cells[finalResultColumnIndex].Style.ForeColor = button1.ForeColor;
                    }
                    else
                    {
                        rowCell.Cells[finalResultColumnIndex].Style.BackColor = rowCell.Cells[0].Style.BackColor;
                        rowCell.Cells[finalResultColumnIndex].Style.ForeColor = rowCell.Cells[0].Style.ForeColor ;
                    }
                }
            });

        }

        private List<DashboardModel> listRunning = new List<DashboardModel>();
        private DashboardModel DashboardModel
        {
            get => _dashboardmodel; set
            {
                _dashboardmodel = value;
            }
        }
        public DashboardForm()
        {
            InitializeComponent();
            meshController = Program.ServiceProvider.GetRequiredService<MESHController>();
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
            kilewController = Program.ServiceProvider.GetRequiredService<KilewController>();

        }

        private async void DashboardForm_Load(object sender, EventArgs e)
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
            _ = Task.Run(() => CheckEmergency());
            _ = Task.Run(() => ReadScrewingKilew());
            _ = Task.Run(() => ReadLaserPLC());
            _ = Task.Run(() => ReadCamera());

            _ = Task.Run(() => OutputTransaction());
//            _ = Task.Run(() => CheckReady());
            _ = Task.Run(() => ShiftQueues());

            _ = Task.Run(() => ShiftTrigger());
            _ = Task.Run(CheckHandSensor);
            await LoadData();
            //Task.Run(async () =>
            //{
            //    await Task.Delay(1000);
            //    await InvokeAsync(() =>
            //    {
            //        screwingResultLabel.Text = "OK";
            //        laserResultLabel.Text = "NG";
            //    });
            //});
            //            textBox1.Text = "test";
        }

        private async Task SetDashboardControl(DashboardModel model)
        {
            DashboardModel = model;
            try
            {
                
                await InvokeAsync(() =>
                {
                        try
                        {
                        torqueLabel.Text = $"{model.Torque.ToString("0.0000")} {model.TorqueType}";
                        screwingResultLabel.Text = model.TighteningStatus;
                        screwingTimeLabel.Text = $"{model.Time} Seconds";
                        laserResultLabel.Text = LaserQueue.Count > 0 &&   LaserQueue.Peek().isLaseringCompleted ? (LaserQueue.Peek().LaserResult ? "OK" : "NG") : (!model.isLaseringReady ? "Checking" : model.LaserStatus ? "OK" : "NG")  ;
                        cameraResultLabel.Text = CameraQueue.Count > 0 && CameraQueue.Peek().isCameraCompleted ? (CameraQueue.Peek().CameraResult ? "OK" : "NG")  : ( !model.isCameraReady ? "Checking" : model.CameraStatus ? "OK" : "NG");
                    }
                    catch { }
                });
            }
            catch { }
        }
        private async Task ReadCamera()
        {
            while (true)
            {
                try
                {
                    //await semaphore.WaitAsync();
                    if (CameraQueue.Count > 0 && !CameraQueue.Peek().isCameraCompleted && meshSend)
                    {
                        PLCController.PLCItem[] commands = [
                            new PLCController.PLCItem("RD", "MR810", -1, "Read For Check if ready"),
//                        new PLCController.PLCItem("RD", "R1004", -1, "Read Camera before read"),
  //                          new PLCController.PLCItem("RD", "MR008", -1, "Read if stepper is running"),
                        ];
                        Task<string>[] Tasks = new Task<string>[3];
                        for (int i = 0; i < commands.Length; i++)
                            Tasks[i] = Task.Run(async () => await plcController.Send(commands[i]));
                        await Task.WhenAll(Tasks);
                        string[] valids = new string[3];
                        for (int i = 0; i < commands.Length; i++)
                            valids[i] = await Tasks[i];
                        var mdl = DashboardModel;
                        if (valids[0] != "1" || valids[1] != "1" || valids[2] == "1")
                        {
                            mdl.isCameraReady = false;
                            await SetDashboardControl(mdl);
                            CameraQueue.Peek().isCameraCompleted = false;
                      //      semaphore.Release();
                            continue;
                        }
                        DashboardModel.StartCamera = DateTime.Now;

                        mdl.isCameraReady = true;
                        await SetDashboardControl(mdl);
                    //    semaphore.Release();
                        PLCController.PLCItem[] cmd = [
                            new PLCController.PLCItem("RD", "MR500", -1, "Read For Reading Camera NG"),
                            new PLCController.PLCItem("RD", "MR501", -1, "Read For Reading Camera OK")
                        ];

                        List<Task<string>> task = [
                            Task.Run<string>(async () => await plcController.Send(cmd[0])),
                            Task.Run<string>(async () => await plcController.Send(cmd[1]))
                        ];
                        await Task.WhenAll(task);
                        string OK = await task[1], NG = await task[0];
                        bool result = false;
                        bool isValid = !string.IsNullOrEmpty(OK) && !string.IsNullOrEmpty(NG);
                        bool check = OK == "0" && NG == "0";
                        result = !check && (OK == "1" && NG == "0");
                        DashboardModel model = DashboardModel;
                        model.CameraStatus = result;
                        await SetDashboardControl(model);

                        var item = CameraQueue.Peek();
                        item.CameraStartTime = DashboardModel.StartCamera;
                        item.CameraEndTime = DateTime.Now;
                        item.CameraResult = DashboardModel.CameraStatus;
                        item.isCameraCompleted = true;
                        await plcController.Send(new PLCController.PLCItem("WR", "MR006", 0, "Disabling Start Button", false));
                        //                        await Task.Delay(1000);
                        await ShiftCameraToFinal();
                    }
                   // semaphore.Release();
                }

                catch (Exception ex)
                {
                    //semaphore.Release();
                    Debug.WriteLine(ex.Message + "|" + ex.StackTrace);
                }
            }
        }
        private async Task OutputTransaction()
        {
            while (true)
            {
                try
                {
                    if (FinalQueue.Count < 1)
                        continue;
                    var item = FinalQueue.Peek();
                    if (item is null) continue;
                    item.FinalResult = item.ScrewingResult && item.LaserResult && item.CameraResult ? "OK" : "NG";
                    item.CurrentStatus = "Completed";
                    if (Settings1.Default.mesActive)
                        await meshController.Tracking(item.OperationUserSN, workNumberScanBox.Text, item.Scan_ID, item.Scan_ID2, item.FinalResult, item); ;
                    await TransactionRepository.CreateTransaction(item);
                    RegisteredItem.Enqueue(FinalQueue.Dequeue());
                    await LoadData();
                }
                catch (Exception ex)
                {
                    LogModel log = new LogModel("Outputting Transaction", "Output Transaction function", "Exception handler for handling unexpected error in loop and continue the loop", "Failed");
                    log.result = $"{ex.Message} | {ex.StackTrace}";
                    await logRepository.RecordLog(log);
                }
                finally
                {
                    await Task.Delay(500);
                }
            }
        }
        private async Task ReadLaserPLC()
        {

            while (true)
            {
                try
                {

                    var mdl = DashboardModel;
                    if (LaserQueue.Count < 1)
                    {
                        mdl.isLaseringReady = false;
                        await SetDashboardControl(mdl);
                        continue;
                    }

                    if (!meshSend)
                    {
                        mdl.isLaseringReady = false;
                        await SetDashboardControl(mdl);
                        continue;
                    }
                    PLCController.PLCItem[] commands = [
                        new PLCController.PLCItem("RD", "MR810", -1, "Read For Check if ready"),
                    //    new PLCController.PLCItem("RD", "R105", -1, "Read Laser before read"),
                      //  new PLCController.PLCItem("RD", "MR008", -1, "Read if stepper running")
                        ];
                    string[] valids = await plcController.Sends(commands);
                    if (valids[0] != "1" || valids[1] != "1" || valids[2] == "1")
                    {
                        mdl.isLaseringReady = false;
                        await SetDashboardControl(mdl);
                        continue;
                    }

                    mdl.isLaseringReady = true;
                    await SetDashboardControl(mdl);
                    await ReadingLaser();
                }
                catch (Exception ex)
                {
                    LogModel log = new LogModel("Read PLC Loop Data", "ReadPLC function", "Exception handler for handling unexpected error in loop and continue the loop", "Failed");
                    log.result = $"{ex.Message} | {ex.StackTrace}";
                    await logRepository.RecordLog(log);
                }
            }
        }
        private async Task ReadScrewingKilew()
        {
            while (true)
            {
                try
                {
                    if (ScrewingQueue.Count < 1)
                        continue;
                    Task<DashboardModel> screwingTask = Task.Run(async () => await ReadingScrewing());
                    DashboardModel model = await screwingTask;
                    model.LaserStatus = DashboardModel.LaserStatus;
                    model.CameraStatus = DashboardModel.CameraStatus;
                    model.isCameraReady = DashboardModel.isCameraReady;
                    model.isLaseringReady = DashboardModel.isLaseringReady;
                    model.StartScrewing = DashboardModel.StartScrewing;
                    model.StartCamera = DashboardModel.StartCamera;
                    model.StartLaser = DashboardModel.StartLaser;
                    await SetDashboardControl(model);
                    await LoadData();
                }
                catch (Exception ex)
                {
                    LogModel log = new LogModel("Read Incoming Data", "ReadIncomingData function", "Exception handler for handling unexpected error in loop and continue the loop", "Failed");
                    log.result = $"{ex.Message} | {ex.StackTrace}";
                    await logRepository.RecordLog(log);
                }
            }
        }
        private async Task CheckReady()
        {
            while (true)
            {

                var cmd = new PLCController.PLCItem("RD", "MR810", -1, "Read For Check if ready");
                var rd = await plcController.Send(cmd);
                var mdl = DashboardModel;
                if (string.IsNullOrEmpty(rd) || rd == "0")
                {
                    mdl.isLaseringReady = false;
                    mdl.isCameraReady = false;
                }
                else if (rd == "1")
                {
                    mdl.isLaseringReady = true;
                    mdl.isCameraReady = true;

                }
                DashboardModel = mdl;
            }
        }
        private async Task<bool> ReadingLaser()
        {
            bool result = false;
            var mdl = DashboardModel;
            if (LaserQueue.Count > 0 && !LaserQueue.Peek().isLaseringCompleted && mdl.isLaseringReady)
            {
                bool check = false;
                do
                {
                    PLCController.PLCItem[] cmd = [
                    new PLCController.PLCItem("RD", "MR502", -1, "Read For Reading Laser NG"),
                    new PLCController.PLCItem("RD", "MR503", -1, "Read For Reading Laser OK")
                    ];
                    await Task.Delay(1000);
                    List<Task<string>> task = [
                    Task.Run<string>(async () => await plcController.Send(cmd[0])),
                    Task.Run<string>(async () => await plcController.Send(cmd[1]))
                    ];
                    DashboardModel.StartLaser = DateTime.Now;
                    await Task.WhenAll(task);
                    string OK = await task[1], NG = await task[0];
                    check = OK == "0" && NG == "0";
                    bool isValid = !string.IsNullOrEmpty(OK) && !string.IsNullOrEmpty(NG);
                    result = !check && (OK == "1" && NG == "0");
                }
                while (check);
                var item = LaserQueue.Peek();
                item.LaserResult = result;
                item.LaserStartTime = DashboardModel.StartLaser;
                item.LaserEndTime = DateTime.Now;
                item.isLaseringCompleted = true;
                DashboardModel model = DashboardModel;
                model.LaserStatus = result;
                model.isLaseringReady = true;
                await SetDashboardControl(model);
                await plcController.Send(new PLCController.PLCItem("WR", "MR006", 0, "Disabling Start Button", false));
                await LoadData();
            }
            return result;
        }
        private async Task<DashboardModel> ReadingScrewing()
        {
            DashboardModel model = new DashboardModel();
            model.StartScrewing = DateTime.Now;
            string res = await kilewController.Send("DATA100");
            string[] data = res.Split(",");
            if (data.Length < 28)
                throw new Exception("Invalid Data");
            if (data[0].Contains("REQ100"))
            {
                res = await kilewController.Send("CMD100");
            }
            //                        string tt =
            //"{DATA100,2025,06,01,16,56,50,2154,7592,4,001,T02VE00007__________,C14Z-E00812_________,0000000017,01,01,01,4Nm___,01,000.00000,1,0021.4500,0139.6,01/01,1,3NG-F,9,}";//28
            if (data[0].Replace("{", "").Contains("DATA100"))
            {
                //{DATA100,2025,07,08,16,06,39,2101,7539,4,001,T02VE00324__________,C14Z-E01595_________,0000000376,01,01,01,Sequn_,01,0004.0250,1,0001.4790,0008.6,00/01,1,OKALL,0,}
                model.ScrewTotal = int.Parse(data[23].Split('/')[1]);
                model.ScrewCount = int.Parse(data[23].Split('/')[0]);
                model.DeviceID = data[10];
                model.TighteningStatus = data[25];
                model.Thread = Convert.ToDecimal(data[22], new CultureInfo("en-US"));
                model.Time = data[21];
                model.Torque = Convert.ToDecimal(data[19], new CultureInfo("en-US"));
                model.TorqueType = "Nm";//data[18].Replace("_", "");
                NEW_CHECKSUM_SCREWING = data[7];
                if (ScrewingQueue.Count > 0)
                {
                    CHECKSUM_SCREWING = NEW_CHECKSUM_SCREWING;
                    var item = ScrewingQueue.Peek();
                    item.Torque = model.Torque;
                    item.TighteningStatus = model.TighteningStatus;
                    item.ScrewingResult = model.TighteningStatus.Contains("OK");
                    item.ScrewingTime = model.Time;
                    item.ThreadCount = model.Thread;
                    item.ScrewStartTime = model.StartScrewing;
                    item.ScrewEndTime = DateTime.Now;
                    item.CHECKSUM = data[7];

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
        private async Task ShiftQueues()
        {
            while (true)
            {

                var res = await plcController.Send(new PLCController.PLCItem("RD", "MR006", -1, "Reading Start Button", false));
                if (res is not null && res == "1")
                {
                    meshSend = false;
                    await Task.Delay(200);
                    //var plcItem = new PLCController.PLCItem("RD", "CR8401", -1, "", false);
                    //bool checkCR = false;
                    //do
                    //{
                    //    var data = await plcController.Send(plcItem);
                    //    checkCR = data == "1";
                    //}
                    //while (!checkCR);
                    //await plcController.Send(new PLCController.PLCItem("WR", "MR006", 0, "Disabling Start Button", false));
                    //                    await OutputTransaction();
                    //                    await ShiftCamera();

//                    _ = Task.Run(() => ShiftTrigger());
                    //                    await ShiftLaserToCamera();
                    //                    await ShiftScrewingToLaser();
                    meshSend = true;
                }
                await Task.Delay(1);
            }
        }

        private async Task ShiftScrewingToLaser()
        {
            if (ScrewingQueue.Count > 0)
            {
                var model = DashboardModel;
                CHECKSUM_SCREWING = NEW_CHECKSUM_SCREWING;
                var item = ScrewingQueue.Dequeue();
                item.CurrentStatus = "Lasering";
                item.CHECKSUM = CHECKSUM_SCREWING;
                item.isScrewingCompleted = true;
                item.isLaseringCompleted = false;
                LaserQueue.Enqueue(item);
            }
        }
        private async Task ShiftLaserToCamera()
        {
            if (LaserQueue.Count > 0 )
            {
                if (!LaserQueue.Peek().isLaseringCompleted)
                    return;
                var item = LaserQueue.Dequeue();
                var mdl = DashboardModel;
                mdl.isCameraReady = false;
                item.isCameraCompleted = false;
                await SetDashboardControl(mdl);
                item.CurrentStatus = "Camera";
                CameraQueue.Enqueue(item);
            }
        }
        private async Task ShiftCameraToFinal()
        {
            try
            {
                if (CameraQueue.Count > 0)
                {
                    var item = CameraQueue.Dequeue();
                    item.CurrentStatus = "Write output file";
                    item.FinalResult = item.ScrewingResult && item.LaserResult && item.CameraResult ? "OK" : "NG";
                    var cmd = new PLCController.PLCItem("RD", "MR008", -1, "Stepper Check");
                    string res = "1";
                    do
                    {
                        res = await plcController.Send(cmd);
                    }
                    while (res == "1");
                    if (item.FinalResult == "NG")
                    {
                        await plcController.Send(new PLCController.PLCItem("WR", "MR1000", 1, "After Camera Read 0 ON"));
                        //                    await Task.Delay(1000);
                        //                    await plcController.Send(new PLCController.PLCItem("WR", "MR1000", 0, "After Camera Read - OFF"));
                    }
                    item.isCameraCompleted = true;
                    FinalQueue.Enqueue(item);
                }
            }
            catch
            {

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("dd-MMM-yy HH:mm:ss");
        }


        private void configToolStripMenuItem_Click(object sender, EventArgs e)
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



        private async void inputFileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            await Task.Delay(1000);
            string text = File.ReadAllText(e.FullPath);
            try
            {
                await logRepository.RecordLog(new LogModel("Input-File", "inputFileWatcher_Changed", "Reading input file from mesh", "Success") { payload = e.FullPath, result = text });

                InputFileModel? input = null;
                try
                {
                    var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(text);
                    var pair = dict.First();
                    input = new InputFileModel(pair.Key.Split(":").First(), pair.Key.Split(":").Last(), pair.Value);
                }
                catch { }
                if (input is null)
                {
                    string[] data = text.Split(':');
                    input = new InputFileModel(data[0], data[1], data[2]);
                }
                if (input is null)
                {
                    await logRepository.RecordLog(new LogModel("Input-File", "inputFileWatcher_Changed", "Reading input file from mesh, format invalid", "Success") { payload = e.FullPath, result = text });
                    return;
                }
                string scan = input.serialnumber;
                string scan2 = input.serialnumber2;
                File.Delete(e.FullPath);
                if (input.status == "OK" || input.status.Contains("PASS"))
                {
                    await plcController.Send(new PLCController.PLCItem("WR", "MR811", 1, "Starting Transaction - ON"));
                    //                    await Task.Delay(3000);
                    //                    await plcController.Send(new PLCController.PLCItem("WR", "MR811", 0, "Starting Transaction - OFF"));
                    ScrewingQueue.Enqueue(new OngoingItemModel() { Scan_ID = scan, Scan_ID2 = scan2, StartTime = DateTime.Now, CurrentStatus = "Screwing" });
                }
            }
            catch (Exception ex)
            {
                await logRepository.RecordLog(new LogModel("Input-File", "inputFileWatcher_Changed", "Reading input file from mesh", "Failed") { payload = e.FullPath, result = ex.Message + " | " + ex.StackTrace });
            }
        }
        private void ShiftScanToScrewing(OngoingItemModel item)
        {
            item.CurrentStatus = "Screwing";
            item.StartTime = DateTime.Now;
            ScrewingQueue.Enqueue(item);
        }
        private void ShiftToStandby(OngoingItemModel item)
        {
            item.CurrentStatus = "-";
            StandbyQueue.Enqueue(item);
        }
        private async Task CheckHandSensor()
        {
            PLCController.PLCItem item = new PLCController.PLCItem("RD", "MR814", -1, "Check hand sensor");
            while (true)
            {
                var res = await plcController.Send(item);
                bool handOff = res == "0";
                await InvokeAsync(() =>
                {
                    bool prev = scan1Box.Enabled;
                    scan1Box.Enabled = handOff;
                    scan2Box.Enabled = handOff;
                    if (handOff && !prev)
                    {
                        scan1Box.Clear();
                        scan2Box.Clear();
                        scan1Box.Focus();

                    }
                });
                await Task.Delay(100);
            }
        }
        private async Task ShiftTrigger()
        {
            while (true)
            {
                try
                {
                    bool shiftClear = false;
                    PLCController.PLCItem shiftPlc = new PLCController.PLCItem("RD", "MR008", -1, "Check if stepper run");
                    runTrigger = true;
                    do
                    {
                        try
                        {
                            await Task.Delay(100);
                            string res = await plcController.Send(shiftPlc);
                            shiftClear = res == "1";
                        }
                        catch { }
                    }
                    while (!shiftClear);
                    await ShiftLaserToCamera();
                    await ShiftScrewingToLaser();
                    if (StandbyQueue.Count > 0)
                        ShiftScanToScrewing(StandbyQueue.Dequeue());
                    do
                    {
                        try
                        {
                            await Task.Delay(100);
                            string res = await plcController.Send(shiftPlc);
                            shiftClear = res == "0";
                        }
                        catch { }
                    }
                    while (!shiftClear);
                }
                catch { }
                finally { }
            }
        }
        private async Task LoadScanToStart(string operationusersn, string scan, string scan2, string worknumberorer)
        {
            var item = new OngoingItemModel() { Scan_ID = scan, Scan_ID2 = scan2, WorkNumber = worknumberorer,isScrewingCompleted=false, OperationUserSN = operationusersn, OperationId = Settings1.Default.OPERATION_ID, CurrentStatus = "Screwing" };
            try
            {
                MesResponse? res = Settings1.Default.mesActive ? await meshController.Checking(operationusersn,worknumberorer, scan, scan2) : new MesResponse() { code = 1, data = "", message = "" };
                if (res is not null)
                {
                    if (res.code == 1)
                    {
                        meshSend = false;
                        var mesh = await plcController.Send(new PLCController.PLCItem("WR", "MR811", 1, "Starting Transaction - ON"));
                        ShiftToStandby(item);
                        meshSend = true;
                    }
                    else if (res.code == -1 && res.message is not null)
                    {
                        await InvokeAsync(() =>
                        MessageBox.Show(res.message, "Transaction Cancelled"));
                    }

                }
                await LoadData();
            }
            catch (TaskCanceledException _)
            {

                await InvokeAsync(() =>
                MessageBox.Show("Can't connect to MES API", "Transaction Cancelled"));
            }
            catch (HttpRequestException ex)
            {
                await InvokeAsync(() =>
                MessageBox.Show("Can't connect to MES API", "Transaction Cancelled"));
            }
            catch (Exception ex)
            {
                await logRepository.RecordLog(new LogModel("Load Scan", "LoadScanToStart", "Reading user scan", "Failed") { payload = JsonSerializer.Serialize(item), result = ex.Message + " | " + ex.StackTrace });
            }
            finally
            {
                try
                {
                    await InvokeAsync(() =>
                    {
                        //                      userIdBox.Text = userIdBox.Tag?.ToString();
                        scan1Box.Clear();
                        scan2Box.Clear();
                        //                        workNumberScanBox.Text = workNumberScanBox.Tag?.ToString();
                        scan1Box.Focus();
                    });
                }
                catch
                {

                }
            }
        }
        private void runningQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (var frm = new LoginForm())
            {
                var result = frm.ShowDialog();
                var usr = frm.GetLogin();
                if (result == DialogResult.OK && usr != null)
                {
                    var frm2 = new RunningQueue(this);
                    frm2.Show();
                }
            }
        }

        public Task<IOStatusForm.IOStatus> GetStatus()
        {
            return Task.FromResult(new IOStatusForm.IOStatus(kilewController.isActive, plcController.isActive));
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new IOStatusForm(this);
            frm.Show();
        }

        private void sampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new SampleForm())
                frm.ShowDialog();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new LogForm();
            frm.Show();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void screwingResultLabel_TextChanged(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            if (lbl.Text.Contains("NG") || lbl.Text.Contains("OK") || lbl.Text == "OKALL" || lbl.Text.Contains("PASS"))
                lbl.ForeColor = lbl.Text.Contains("NG") ? ColorTranslator.FromHtml("#EF4444") : ColorTranslator.FromHtml("#10B981");
        }

        private void screwingResultLabel_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = (Label)sender;
            if (lbl.Text == "NG" || lbl.Text == "OK" || lbl.Text == "PASS")
                lbl.ForeColor = lbl.Text == "NG" ? ColorTranslator.FromHtml("#EF4444") : ColorTranslator.FromHtml("#10B981");
            else
                lbl.ForeColor = label3.ForeColor;

        }

        public async void DequeueScrewing(bool isOk)
        {
            Random rnd = new Random();
            var item = ScrewingQueue.Dequeue();
            item.Torque = Convert.ToDecimal(rnd.NextDouble() * 100);
            item.TighteningStatus = isOk ? "OK" : "NG";
            item.ScrewingResult = isOk;
            item.ScrewingTime = Convert.ToDecimal(rnd.NextDouble() * 100).ToString("0.00");
            item.ThreadCount = rnd.Next(0, 10);
            item.ScrewStartTime = DateTime.Now.AddSeconds(rnd.Next(0, 10) * -1);
            item.ScrewEndTime = DateTime.Now;
            item.CurrentStatus = "Lasering";
            item.CHECKSUM = "32242494";
            item.isScrewingCompleted = true;
            LaserQueue.Enqueue(item);
            await LoadData();
        }

        public async void DequeueLaser(bool isOK)
        {
            Random rnd = new Random();
            var item = LaserQueue.Dequeue();
            item.LaserResult = isOK;
            item.LaserStartTime = DateTime.Now.AddSeconds(rnd.Next(0, 10) * -1);
            item.LaserEndTime = DateTime.Now;
            item.CurrentStatus = "Camera";
            item.isLaseringCompleted = true;
            CameraQueue.Enqueue(item);
            await LoadData();
        }

        public async void DequeueCamera(bool isOk)
        {
            Random rnd = new Random();
            var item = CameraQueue.Dequeue();
            item.CameraStartTime = DateTime.Now.AddSeconds(rnd.Next(0, 10) * -1);
            item.CameraEndTime = DateTime.Now;
            item.CameraResult = isOk;
            item.CurrentStatus = "Write output file";
            item.FinalResult = item.ScrewingResult && item.LaserResult && item.CameraResult ? "OK" : "NG";
            item.isCameraCompleted = true;
            FinalQueue.Enqueue(item);
            await LoadData();
        }

        public async void ResetOutput()
        {
            string path = Settings1.Default.Output_Path;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.GetFiles().Length > 0)
            {
                foreach (var file in dirInfo.GetFiles())
                    File.Delete(file.FullName);
            }
            await LoadData();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new LoginForm())
            {
                var result = frm.ShowDialog();
                var usr = frm.GetLogin();
                if (result == DialogResult.OK && usr != null)
                {
                    var frm2 = new QueueManual(this, this);
                    frm2.Show();
                }
            }
        }


        private void scanBoxLeave(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;

            box.Text = string.IsNullOrEmpty(box.Text) || string.IsNullOrWhiteSpace(box.Text) ? box.Tag?.ToString() : box.Text;

        }

        private void ScanFocus(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;

            box.Text = box.Text == box.Tag?.ToString() ? string.Empty : box.Text;

        }

        private async void userIdBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                if ((!string.IsNullOrEmpty(scan1Box.Text) && !string.IsNullOrEmpty(scan2Box.Text) && !string.IsNullOrEmpty(userIdBox.Text)) && !string.IsNullOrEmpty(workNumberScanBox.Text) &&
                    (scan1Box.Text != scan1Box.Tag?.ToString() && scan2Box.Text != scan2Box.Tag?.ToString() && userIdBox.Text != userIdBox.Tag?.ToString()) && workNumberScanBox.Text != workNumberScanBox.Tag?.ToString())
                {
                    await LoadScanToStart(userIdBox.Text, scan1Box.Text, scan2Box.Text, workNumberScanBox.Text);
                }
                else
                {
                    scan1Box.Focus();
                }
            }
        }

        private async void scan1Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if ((!string.IsNullOrEmpty(scan1Box.Text) && !string.IsNullOrEmpty(scan2Box.Text) && !string.IsNullOrEmpty(userIdBox.Text)) && !string.IsNullOrEmpty(workNumberScanBox.Text) &&
                    (scan1Box.Text != scan1Box.Tag?.ToString() && scan2Box.Text != scan2Box.Tag?.ToString() && userIdBox.Text != userIdBox.Tag?.ToString()) && workNumberScanBox.Text != workNumberScanBox.Tag?.ToString())
                {
                    await LoadScanToStart(userIdBox.Text, scan1Box.Text, scan2Box.Text, workNumberScanBox.Text);
                }
                else
                {
                    scan2Box.Focus();
                }
            }
        }

        private async void scan2Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if ((!string.IsNullOrEmpty(scan1Box.Text) && !string.IsNullOrEmpty(scan2Box.Text) && !string.IsNullOrEmpty(userIdBox.Text)) && !string.IsNullOrEmpty(workNumberScanBox.Text) &&
                    (scan1Box.Text != scan1Box.Tag?.ToString() && scan2Box.Text != scan2Box.Tag?.ToString() && userIdBox.Text != userIdBox.Tag?.ToString()) && workNumberScanBox.Text != workNumberScanBox.Tag?.ToString())
                {
                    await LoadScanToStart(userIdBox.Text, scan1Box.Text, scan2Box.Text, workNumberScanBox.Text);
                }
                else
                {
                    workNumberScanBox.Focus();
                }
            }
        }

        private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if ((!string.IsNullOrEmpty(scan1Box.Text) && !string.IsNullOrEmpty(scan2Box.Text) && !string.IsNullOrEmpty(userIdBox.Text)) && !string.IsNullOrEmpty(workNumberScanBox.Text) &&
                    (scan1Box.Text != scan1Box.Tag?.ToString() && scan2Box.Text != scan2Box.Tag?.ToString() && userIdBox.Text != userIdBox.Tag?.ToString()) && workNumberScanBox.Text != workNumberScanBox.Tag?.ToString())
                {
                    await LoadScanToStart(userIdBox.Text, scan1Box.Text, scan2Box.Text, workNumberScanBox.Text);
                }
                else
                {
                    userIdBox.Focus();
                }
            }
        }

        public async void StartTransaction()
        {
            Random rnd = new Random();
            await LoadScanToStart("1030422494", rnd.Next(10000, 99999).ToString("D5"), rnd.Next(10000, 99999).ToString("D5"), "BM249942942");
        }

        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new LoginForm())
            {
                var result = frm.ShowDialog();
                var usr = frm.GetLogin();
                if (result == DialogResult.OK && usr != null)
                {
                    var frm2 = new MaintenanceForm();
                    frm2.Show();
                }
            }
        }
        private async Task CheckEmergency()
        {
            PLCController.PLCItem[] plcReads = [
                new PLCController.PLCItem("RD", "R10", -1, "Read Emergency",false),
                new PLCController.PLCItem("RD", "R100", -1, "Read Pause",false),
            ];

            while (true)
            {
                try
                {
                    Task<string>[] Tasks = [Task.Run(async () => await plcController.Send(plcReads[0])), Task.Run(async () => await plcController.Send(plcReads[1]))];
                    await Task.WhenAll(Tasks);
                    bool pause = (await Tasks[1]) == "1";
                    bool emergency = (await Tasks[0]) == "0";
                    if (pause || emergency)
                    {
                        msgDialogue = new EmergencyDialogue();
                        msgDialogue.StartPosition = FormStartPosition.CenterParent;
                        await InvokeAsync(() => {
                            var res  = msgDialogue.ShowDialog();
                            Task.Run(() => CheckEmergency());
                        });
                        return;
                    }
                    await Task.Delay(100);
                }
                catch { }
            }
        }

        public interface IDashboardOngoingItems
        {
            Task<List<OngoingItemModel>> GetOngoingItems();
        }
    }
}
