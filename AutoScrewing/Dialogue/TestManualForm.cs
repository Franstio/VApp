using AutoScrewing.Lib;
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
    public partial class TestManualForm : Form
    {
        private PLCController PLCController;
        public TestManualForm(PLCController pLCController)
        {
            InitializeComponent();
            PLCController = pLCController;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await InvokeAsync(()=>button1.Enabled=false);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2001", 1, ""));
            await Task.Delay(100);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2001", 0, ""));
            await InvokeAsync(() => button1.Enabled = true);
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            await InvokeAsync(() => button2.Enabled = false);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2002", 1, ""));
            await Task.Delay(100);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2002", 0, ""));

            await InvokeAsync(() => button2.Enabled = true);
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            await InvokeAsync(() => button3.Enabled = false);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2003", 1, ""));
            await Task.Delay(100);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2003", 0, ""));
            await InvokeAsync(() => button3.Enabled = false);
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            await InvokeAsync(() => button4.Enabled = false);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2004", 1, ""));
            await Task.Delay(100);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2004", 0, ""));

            await InvokeAsync(() => button4.Enabled = false);
        }
    }
}
