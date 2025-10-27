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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoScrewing.Dialogue.MaintenanceControls
{
    public partial class ResetMeshControl : UserControl,IMaintenanceControl
    {
        public record MaintenanceData(string inputText, string outputText, PLCController.PLCItem OutputEnableCommand, PLCController.PLCItem OutputDisableCommand, PLCController.PLCItem InputCommand);
        private PLCController plcController;
        private CancellationTokenSource tokenCancel;
        private readonly Image redImage, greenImage;
        private readonly MaintenanceData maintenanceData;

        public ResetMeshControl()
        {
            InitializeComponent();
            maintenanceData = new MaintenanceData("Check MR006", "", new PLCController.PLCItem("RD", "MR901", 1, ""), new PLCController.PLCItem("WR", "MR901", 0, ""), new PLCController.PLCItem("RD", "MR006", -1, ""));
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
            tokenCancel = new CancellationTokenSource();
            redImage = LoadImage(Properties.Resources.red_circle);
            greenImage = LoadImage(Properties.Resources.green_circle);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Padding = new Padding(10);
            inputLabel.Text = maintenanceData.inputText;
            plcController = Program.ServiceProvider.GetRequiredService<PLCController>();
            tokenCancel = new CancellationTokenSource();
            _ = Task.Run(Read);
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


        private async Task Read()
        {
            while (!tokenCancel.IsCancellationRequested)
            {
                try
                {
                    tokenCancel.Token.ThrowIfCancellationRequested();
                    var res = await plcController.Send(maintenanceData.InputCommand);
                    bool val = res == "1";
                    await InvokeAsync(() =>
                    {
                        pictureBox1.Image = val ? greenImage : redImage;
                    });
                    await Task.Delay(50);
                }
                catch (OperationCanceledException e)
                {
                    return;
                }
                catch (Exception _)
                {
                    continue;
                }
            }
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            string oldtext = button1.Text;
            var oldColor = button1.BackColor;
            await InvokeAsync(() =>
            {
                button1.BackColor = Color.Red;
                button1.Text = "Trigger Running";
            });
            await plcController.Send(new PLCController.PLCItem("WR","MR910",1,""));
            await Task.Delay(100);
            await plcController.Send(new PLCController.PLCItem("WR", "MR910", 0, ""));
            await Task.Delay(500);
            await InvokeAsync(() =>
            {
                button1.BackColor = oldColor;
                button1.Text = oldtext;
            });
        }
    }
}
