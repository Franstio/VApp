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

    public partial class EmergencyDialogue : Form
    {
        PLCController plcController;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public EmergencyDialogue()
        {
            InitializeComponent();
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
        }
        public EmergencyDialogue(string message)
        {
            InitializeComponent();
            this.label1.Text = message;
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
        }
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private async Task WaitForComplete()
        {
            PLCController.PLCItem[] plcReads = [
                new PLCController.PLCItem("RD", "R10", -1, "Read Emergency",false),
                new PLCController.PLCItem("RD", "R100", -1, "Read Pause",false),
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
                        Tasks.Add(Task.Run(async () => await plcController.Send(plcReads[1])));
                    }
                    await Task.WhenAll(Tasks);
                    bool pause = (await Tasks[1]) == "1";
                    bool emergency = (await Tasks[0]) == "0";
                    bool jig = (await Tasks[2]) == "1";
                    if (emergency)
                    {
                        await InvokeAsync(() => label1.Text = "Emergency Active");
                    }
                    else if (pause)
                    {
                        await InvokeAsync(() => label1.Text = "Pause Active");
                    }
                    else if (jig)
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
            cancellationTokenSource.Cancel();
        }
    }
}
