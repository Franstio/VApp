using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoScrewing.Dialogue.MaintenanceControls;

namespace AutoScrewing.Dialogue
{
    public partial class MaintenanceForm : Form
    {
        private List<UserControl> boxes = [
//            new MaintenanceBoxControl(new MaintenanceBoxControl.MaintenanceData(""))
              new ReleaseBoxControl()
            ];
        public MaintenanceForm()
        {
            InitializeComponent();
        }

        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            var s = boxes.Select(x =>
            {
                x.Width = flowLayoutPanel1.Width - 10;
                return x;
            }).ToArray();
            flowLayoutPanel1.Controls.AddRange(s);
        }

        private void MaintenanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var box in boxes)
                (box as IMaintenanceControl)?.ClearTask();
        }
    }
}
