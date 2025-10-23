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
    public partial class MaintenanceBoxControl : UserControl,IMaintenanceControl
    {
        public record MaintenanceData(string inputText,string outputText, PLCController.PLCItem OutputEnableCommand, PLCController.PLCItem OutputDisableCommand, PLCController.PLCItem InputCommand);
        private readonly Image redImage, greenImage;
        private readonly MaintenanceData maintenanceData;
        private PLCController plcController;
        private CancellationTokenSource tokenCancel;
        private bool _stateEnable = true;
        private bool StateEnable { get => _stateEnable; 
            set 
            {
                _stateEnable = value;
                button1.Text = value ? "Enable" : "Disable";
                button1.BackColor = value ? ColorTranslator.FromHtml("#10B981") : ColorTranslator.FromHtml("#EF4444") ;
            }
        }
        public MaintenanceBoxControl(MaintenanceData data)
        {
            InitializeComponent();
            Random rnd = new Random();
            bool isGreen = rnd.Next(0, 100) % 2 == 0;
            redImage = LoadImage(Properties.Resources.red_circle);
            greenImage = LoadImage(Properties.Resources.green_circle);
            pictureBox1.Image = isGreen ? greenImage : redImage;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Padding = new Padding(10);
            inputLabel.Text = data.inputText;
            outputLabel.Text = data.outputText;
            maintenanceData = data;
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
            await plcController.Send(StateEnable ? maintenanceData.OutputEnableCommand : maintenanceData.OutputDisableCommand);
            StateEnable = !StateEnable;
        }
    }
}
