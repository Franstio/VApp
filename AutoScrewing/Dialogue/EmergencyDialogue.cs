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
            while (true)
            {
                PLCController.PLCItem r10 = new PLCController.PLCItem("RD", "R10", -1, "Read Emergency", false);
                var res = await plcController.Send(r10);
                if (res == "1")
                    this.Close();
                await Task.Delay(100);
            }
        }
    }
}
