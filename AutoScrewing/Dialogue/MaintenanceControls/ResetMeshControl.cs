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

namespace AutoScrewing.Dialogue.MaintenanceControls
{
    public partial class ResetMeshControl : UserControl,IMaintenanceControl
    {
        private PLCController plcController;
        private CancellationTokenSource tokenCancel;
        
        public ResetMeshControl()
        {
            InitializeComponent();
            Random rnd = new Random();
            bool isGreen = rnd.Next(0, 100) % 2 == 0;
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
            tokenCancel = new CancellationTokenSource();
        }
        public void ClearTask()
        {
            tokenCancel.Cancel();
        }
        Image LoadImage(byte[] data)
        {
            using (var ms = new MemoryStream(data))
                return Image.FromStream(ms);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        



        private async void button1_Click(object sender, EventArgs e)
        {
            await plcController.Send(new PLCController.PLCItem("WR","MR910",1,""));
        }
    }
}
