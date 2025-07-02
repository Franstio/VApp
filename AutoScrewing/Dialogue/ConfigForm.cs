using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewing.Dialogue
{
    public partial class ConfigForm : Form
    {
        private readonly UserConfigModel _userConfigModel;
        private ConfigRepository configRepository = new ConfigRepository();
        public ConfigForm(UserConfigModel usr)
        {
            InitializeComponent();
            _userConfigModel = usr;
        }

        private async void ConfigForm_Load(object sender, EventArgs e)
        {
            await configRepository.LogLogin(_userConfigModel, "Login");
            await InvokeAsync(() =>
            {
                plcBox.Text = Settings1.Default.PLC_TARGET;
                meshUrlBox.Text = Settings1.Default.MESH_URL;
                operationIDBox.Text = Settings1.Default.OPERATION_ID;
                operationUserBox.Text = Settings1.Default.OPERATION_USER;
                string[] ports = SerialPort.GetPortNames();
                screwingBox.Items.AddRange(ports);
                screwingBox.SelectedIndex = screwingBox.Items.IndexOf(Settings1.Default.Screwing_Port); ;
            });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Settings1.Default.PLC_TARGET = plcBox.Text;
            Settings1.Default.Screwing_Port = screwingBox.Text;
            Settings1.Default.Save();
            Settings1.Default.Reload();
            await configRepository.LogLogin(_userConfigModel, "I/O Config Updated");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Settings1.Default.MESH_URL = meshUrlBox.Text;
            Settings1.Default.OPERATION_ID = operationIDBox.Text;
            Settings1.Default.OPERATION_USER = operationUserBox.Text;
            Settings1.Default.Save();
            Settings1.Default.Reload();
            await configRepository.LogLogin(_userConfigModel, "Mesh Config Updated");
        }
    }
}
