using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using Microsoft.Extensions.DependencyInjection;
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
    public partial class TransactionForm : Form
    {
        private TransactionRepository transactionRepository;
        private List<LogModel> logData = new List<LogModel>();
        TransactionRepository.TransactionPagination? pagination;
        DateTime? from = null, to = null;
        public TransactionForm()
        {
            InitializeComponent();
            transactionRepository = Program.ServiceProvider.GetRequiredService<TransactionRepository>();
            numericUpDown1.Value = 1;
        }
        private async Task LoadData(int page)
        {
            pagination = await transactionRepository.GetTransaction(page, 50, from, to);
            try
            {

                await InvokeAsync(() =>
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = pagination.data;
                    dataGridView1.Refresh();
                    numericUpDown1.Value = page;
                    if (pagination.currentPage > 0)
                    {
                        button4.Enabled = pagination.currentPage > 1;
                        button5.Enabled = pagination.currentPage < pagination.totalPage;
                        numericUpDown1.Enabled = true;
                        numericUpDown1.Minimum = 1;
                        numericUpDown1.Maximum = pagination.totalPage;
                    }
                });
            }
            catch
            {

            }
        }

        private async void LogForm_Load(object sender, EventArgs e)
        {
            await LoadData(1);
        }


        private void fromBox_ValueChanged(object sender, EventArgs e)
        {
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            await InvokeAsync(() => button1.Enabled = false);
            var rst = saveFileDialog1.ShowDialog();
            if (rst == DialogResult.OK)
            {
                try
                {
                    await File.WriteAllTextAsync(saveFileDialog1.FileName, JsonSerializer.Serialize(logData));
                }
                catch { }
            }
            await InvokeAsync(() => button1.Enabled = true);

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await InvokeAsync(() => button2.Enabled = false);
            from = fromBox.Value;
            to = toBox.Value;
            await LoadData(1);
            await InvokeAsync(() => button2.Enabled = true);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await InvokeAsync(() => button3.Enabled = false);
            await InvokeAsync(() => button3.Enabled = true);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(numericUpDown1.Value) - 1;
            await LoadData(page);
            if (page > 1)
                numericUpDown1.Value = page;
            else
                await InvokeAsync(() => button4.Enabled = false);
        }

        private async void button5_Click(object sender, EventArgs e)
        {

            int page = Convert.ToInt32(numericUpDown1.Value) + 1;
            await LoadData(page);
            if (page < pagination?.totalPage)
                numericUpDown1.Value = numericUpDown1.Value + 1;
            else
                await InvokeAsync(() => button5.Enabled = false);
        }

        private async void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(numericUpDown1.Value) ;
            await LoadData(page);
        }
    }
}
