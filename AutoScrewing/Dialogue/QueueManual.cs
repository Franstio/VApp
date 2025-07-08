using AutoScrewing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewing.Dialogue
{
    public partial class QueueManual : Form
    {
        public interface IQueueManual
        {
            void DequeueScrewing(bool isOk);
            void DequeueLaser(bool isOK);
            void DequeueCamera(bool isOk);
            void ResetOutput();
        }
        private IQueueManual queueForm;
        private DashboardForm.IDashboardOngoingItems dashboardForm;
        private Dictionary<string, string> QueueData = new Dictionary<string, string>();
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
        public QueueManual(IQueueManual queueForm, DashboardForm.IDashboardOngoingItems ongoingItems)
        {
            InitializeComponent();
            this.queueForm = queueForm;
            dashboardForm = ongoingItems;
            var _ = Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        await Task.Delay(1000);
                        await semaphore.WaitAsync();

                        var data = await ongoingItems.GetOngoingItems();
                        var screwing = data.Where(x => x.CurrentStatus == "Screwing");
                        var lasering = data.Where(x => x.CurrentStatus == "Lasering");
                        var camera = data.Where(x => x.CurrentStatus == "Camera");
                        var outputdata = data.Where(x => x.CurrentStatus == "Write output file");
                        QueueData.Clear();

                        QueueData.Add("Screwing", $"{(screwing.Any() ? screwing.FirstOrDefault()?.Scan_ID : '-')} (x{screwing.Count()}) ");

                        QueueData.Add("Lasering", $"{(lasering.Any() ? lasering.FirstOrDefault()?.Scan_ID : '-')} (x{lasering.Count()}) ");
                        QueueData.Add("Camera", $"{(camera.Any() ? camera.FirstOrDefault()?.Scan_ID : '-')} (x{camera.Count()}) ");
                        DirectoryInfo dirInfo = new DirectoryInfo(Settings1.Default.Output_Path);
                        bool output = dirInfo.GetFiles().Length > 0;
                        QueueData.Add("Output", $"{(output ? "Output Detected" : "No Output Detected")} (x{outputdata.Count()})");
                        await InvokeAsync(() =>
                        {
                            try
                            {
                                ScrewingLabel.Text = QueueData["Screwing"];
                                LaserLabel.Text = QueueData["Lasering"];
                                CameraLabel.Text = QueueData["Camera"];
                                OutputLabel.Text = QueueData["Output"];
                                button7.Enabled = output;
                            }
                            catch
                            {

                            }
                        });
                        semaphore.Release();
                    }
                    catch
                    {
                        semaphore.Release();
                    }
                }
            });
        }

        private void screwingQueueClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            bool isOk = btn.Tag?.ToString() == "1";
            queueForm.DequeueScrewing(isOk);
        }

        private void laserQueueClick(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            bool isOk = btn.Tag?.ToString() == "1";
            queueForm.DequeueLaser(isOk);
        }

        private void cameraQueueClick(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            bool isOk = btn.Tag?.ToString() == "1";
            queueForm.DequeueCamera(isOk);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            queueForm.ResetOutput();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            var inp = new InputFileModel(rnd.Next(10000,100000).ToString(), rnd.Next(10000, 100000).ToString(), "OK");
            string payload = JsonSerializer.Serialize(inp);
            File.WriteAllText(Path.Combine(Settings1.Default.Input_Path,"test.json"),payload);
        }
    }
}
