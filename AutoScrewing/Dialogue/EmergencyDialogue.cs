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
        
        public EmergencyDialogue()
        {
            InitializeComponent();
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
            Task.Run(WaitForComplete);
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
            ];

            while (true)
            {

                Task<string>[] Tasks = [Task.Run(async () => await plcController.Send(plcReads[0])), Task.Run(async () => await plcController.Send(plcReads[1]))];
                await Task.WhenAll(Tasks);
                bool pause = (await Tasks[1]) == "1";
                bool emergency = (await Tasks[0]) == "0";
                if (emergency)
                {
                    await InvokeAsync(() => label1.Text = "Emergency Active");
                }
                else if (pause)
                {
                    await InvokeAsync(() => label1.Text = "Pause Active");
                }
                else
                    this.Close();
                await Task.Delay(100);
            }
        }
    }
}
