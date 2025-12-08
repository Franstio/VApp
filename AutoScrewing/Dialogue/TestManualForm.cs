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
            await PLCController.Send(new PLCController.PLCItem("WR", "MR2001", 1, ""));
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            await PLCController.Send(new PLCController.PLCItem("WR", "MR2002", 1, ""));
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            await PLCController.Send(new PLCController.PLCItem("WR", "MR2003", 1, ""));
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            await PLCController.Send(new PLCController.PLCItem("WR", "MR2004", 1, ""));
        }
    }
}
