using AutoScrewing.Models;
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
    public partial class RunningQueue : Form
    {
        List<OngoingItemModel> ongoingItems = [];
        DashboardForm.IDashboardOngoingItems ongoingItemsAPI;
        private CancellationTokenSource cts = new CancellationTokenSource();
        public RunningQueue(DashboardForm.IDashboardOngoingItems ongoingItemsAPI)
        {
            InitializeComponent();
            this.ongoingItemsAPI = ongoingItemsAPI;
            _ = Task.Run(LoadData);
        }
        private async Task LoadData()
        {
            try
            {
                cts.Token.ThrowIfCancellationRequested();
                while (true)
                {
                    ongoingItems = await ongoingItemsAPI.GetOngoingItems();
                    await dataGridView1.InvokeAsync(() =>
                    dataGridView1.Rows.Clear());
                    foreach (var item in ongoingItems)
                    {
                        await dataGridView1.InvokeAsync(() =>
                        dataGridView1.Rows.Add([item.Scan_ID,item.Scan_ID2, item.CurrentStatus, item.StartTime, item.ScrewStartTime, item.ScrewEndTime, item.LaserStartTime, item.LaserEndTime, item.CameraStartTime, item.CameraEndTime])
                        );
                    }
                    await Task.Delay(500);
                }
            }
            catch
            {

            }
        }

        private void RunningQueue_FormClosed(object sender, FormClosedEventArgs e)
        {
            cts.Cancel();
        }
    }
}
