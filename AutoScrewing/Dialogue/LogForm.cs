using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewing.Dialogue
{
    public partial class LogForm : Form
    {
        private LogRepository logRepository = new LogRepository();
        private List<LogModel> logData = new List<LogModel>();
        public LogForm()
        {
            InitializeComponent();
        }
        async Task LoadLogType()
        {

            try
            {
                var logtype = await logRepository.GetLogType();
                await InvokeAsync(() =>
                {
                    logTypeBox.Items.Clear();
                    logTypeBox.Items.AddRange(logtype.ToArray());
                });
            }
            catch { }
        }
        private async Task LoadData()
        {
            await LoadLogType();
            var data = await logRepository.GetLog(logTypeBox.Text, searchBox.Text, fromBox.Value, toBox.Value);
            logData = data.ToList();
            try
            {

                await InvokeAsync(() =>
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = data;
                    dataGridView1.Refresh();
                });
            }
            catch
            {
                
            }
        }

        private async void LogForm_Load(object sender, EventArgs e)
        {
            await LoadLogType();
        }

        private async void logTypeBox_SelectedValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void fromBox_ValueChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void searchBox_TextChanged(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await InvokeAsync(() => button1.Enabled = false);
            var rst =saveFileDialog1.ShowDialog();
            if (rst==DialogResult.OK)
            {
                try
                {
                    await File.WriteAllTextAsync(saveFileDialog1.FileName, JsonSerializer.Serialize(logData));
                }
                catch  { }
            }
            await InvokeAsync(() => button1.Enabled = true);

        }
    }
}
