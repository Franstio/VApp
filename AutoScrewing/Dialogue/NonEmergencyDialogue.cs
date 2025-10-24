using AutoScrewing.Lib;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewing.Dialogue
{

    public partial class NonEmergencyDialogue : Form
    {
        PLCController plcController;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public interface IEmergencyMonitor
        {
            Task CheckEmergency();
        }
        private IEmergencyMonitor monitor;
        public NonEmergencyDialogue(IEmergencyMonitor monitor)
        {
            InitializeComponent();
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
            this.monitor = monitor;
        }
        

        private async Task WaitForComplete()
        {
            PLCController.PLCItem[] plcReads = [
                new PLCController.PLCItem("RD", "MR202",-1,"Read Jig")
            ];

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    List<Task<string>> Tasks = [];
                    for (int i=0;i<plcReads.Length;i++)
                    {
                        var data = plcReads[i];
                        Tasks.Add(Task.Run(async () => await plcController.Send(data)));
                    }
                    await Task.WhenAll(Tasks);
                    bool jig = (await Tasks[0]) == "1";
                    if (jig)
                    {
                        await InvokeAsync(() => label1.Text = "Jig dalam kondisi nyangkut");
                    }
                    else
                        await InvokeAsync(() => this.Close());
                    await Task.Delay(100);
                }
                catch { }
            }
        }

        private void EmergencyDialogue_Load(object sender, EventArgs e)
        {
            Task.Run(WaitForComplete);
        }

        private void EmergencyDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ = Task.Run(monitor.CheckEmergency);
            cancellationTokenSource.Cancel();
        }
    }
}
