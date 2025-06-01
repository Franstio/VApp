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

namespace AutoScrewing
{
    public partial class DashboardForm : Form
    {
        private DashboardModel _dashboardmodel = new DashboardModel();
        private DashboardModel DashboardModel { get => _dashboardmodel;  set {
                _dashboardmodel = value;
                SetDashbaordControl(_dashboardmodel);        
            } 
        }
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            DashboardModel data = new DashboardModel()
            {
                DeviceID = "001",
                Thread = 9,
                Time = new TimeSpan(0, 0, 0, 2, 7210),
                Torque = 0.802M,
                ScrewCount = 1,
                ScrewTotal = 1,
                ProgramSeq = "P1\t1",
                OK=5,
                NG=52,
                OKALL=5,
                Job=1,
                Seq=1,
                TighteningStatus = "3NG-F"
            };
            DashboardModel = data;
        }
        
        private async void SetDashbaordControl(DashboardModel model)
        {
            await InvokeAsync(() =>
            {
                TighteningStatusLabel.Text = model.TighteningStatus;
                TorqueLabel.Text = $"{model.Torque} {model.TorqueType}";
                ScrewCountLabel.Text = $"{model.ScrewCount} of {model.ScrewTotal}";
                TimeLabel.Text = string.Format("{0:00000} Sec", model.Time.TotalSeconds);
                ProgramSeqLabel.Text = model.ProgramSeq;
                ThreadLabel.Text = string.Format("{0:00000}",model.Thread);
                DeviceIDLabel.Text = model.DeviceID;
                OkAllLabel.Text = model.StatusCount.OKALL.ToString();
                OkCountLabel.Text = model.StatusCount.OK.ToString();
                NgCountLabel.Text = model.StatusCount.NG.ToString();
                jobLabel.Text = model.JobSeq.Job.ToString();
                SeqLabel.Text=  model.JobSeq.Seq.ToString();

            });
        }
    }
}
