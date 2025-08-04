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
    public partial class MaintenanceForm : Form
    {
        private List<MaintenanceBoxControl> boxes = [];
        public MaintenanceForm()
        {
            InitializeComponent();
        }

        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            for (int i = 0; i < 9; i++)
            {
                var frm = new MaintenanceBoxControl(new MaintenanceBoxControl.MaintenanceData($"Sensor {i + 1}", $"Jig {i + 1}", new Lib.PLCController.PLCItem("WR", "MR010", 1, ""), new Lib.PLCController.PLCItem("WR", "MR010", 0, ""), new Lib.PLCController.PLCItem("RD", "MR010", -1, "", false)));
                frm.Width = flowLayoutPanel1.Width-10;
                boxes.Add(frm);
            }
            flowLayoutPanel1.Controls.AddRange(boxes.ToArray());
        }

        private void MaintenanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var box in boxes)
                box.ClearTask();
        }
    }
}
