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
        void SwitchButton(Button btn,bool green)
        {
            btn.BackColor = ColorTranslator.FromHtml( green ?  "#27ae60":"#3498db");
            btn.ForeColor = ColorTranslator.FromHtml(green ?  "#bdc3c7": "#ecf0f1"); 
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await InvokeAsync(() => button1.Enabled = false);
            await InvokeAsync(() => SwitchButton(button1, true));
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1200", 1, ""));
            await Task.Delay(100);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1200", 0, ""));
            await InvokeAsync(() => button1.Enabled = true);
            await InvokeAsync(() => SwitchButton(button1, false));
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {

            await InvokeAsync(() => button2.Enabled = false);

            await InvokeAsync(() => SwitchButton(button2, true));
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1201", 1, ""));
            await Task.Delay(2000);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1201", 0, ""));

            await InvokeAsync(() => button2.Enabled = true);

            await InvokeAsync(() => SwitchButton(button2, false));
        }

        private async void button5_Click(object sender, EventArgs e)
        {

            await InvokeAsync(() => button5.Enabled = false);
            await InvokeAsync(() => SwitchButton(button5, true));
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1202", 1, ""));
            await Task.Delay(2000);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1202", 0, ""));
            await InvokeAsync(() => button5.Enabled = true);
            await InvokeAsync(() => SwitchButton(button5, false));
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            await InvokeAsync(() => button3.Enabled = false);
            await InvokeAsync(() => SwitchButton(button3, true));
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1203", 1, ""));
            await Task.Delay(3000);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1203", 0, ""));
            await InvokeAsync(() => button3.Enabled = true);
            await InvokeAsync(() => SwitchButton(button3, false));
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            await InvokeAsync(() => button4.Enabled = false);

            await InvokeAsync(() => SwitchButton(button4, true));
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1204", 1, ""));
            await Task.Delay(100);
            await PLCController.Send(new PLCController.PLCItem("WR", "MR1204", 0, ""));

            await InvokeAsync(() => button4.Enabled = true);
            await InvokeAsync(() => SwitchButton(button4, false));
        }

        
    }
}
