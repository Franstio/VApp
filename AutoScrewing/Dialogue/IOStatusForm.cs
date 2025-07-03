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
    public partial class IOStatusForm : Form
    {
        public interface IOStatusAPI
        {
            Task<IOStatus> GetStatus();
        }
        public record IOStatus(bool screwing,bool plc);
        IOStatusAPI _api;
        public IOStatusForm(IOStatusAPI api)
        {
            InitializeComponent();
            _api = api;
        }

        private async void IOStatusForm_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>LoadData());
        }
        private async Task LoadData()
        {
            while (true)
            {
                IOStatus status = await _api.GetStatus();
                await InvokeAsync(() =>
                {
                    screwingstatus.ForeColor = status.screwing ? Color.Green : Color.Red;
                    plcStatus.ForeColor = status.plc ? Color.Green : Color.Red;
                    screwingstatus.Text = status.screwing ? "Active" : "Inactive";
                    plcStatus.Text = status.plc ? "Active" : "Inactive";
                });
                await Task.Delay(1000);
            }
        }
    }
}
