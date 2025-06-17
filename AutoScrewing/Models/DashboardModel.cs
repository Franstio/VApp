using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Models
{
    public class DashboardModel
    {
        public int OKALL { get; set; } = 0;
        public int NG { get; set; } = 0 ;
        public int OK { get;set; } = 0 ;
        public int Job { get; set; } = 0 ;  
        public int Seq { get; set; } = 0 ;
        public decimal Torque { get; set; } = 0;
        public string TorqueType { get; set; } = "N.m";
        public int ScrewCount { get; set; } = 0 ;
        public int ScrewTotal { get; set; } = 0;
        public TimeSpan Time { get; set; } = TimeSpan.Zero;
        public string ProgramSeq { get;set;} = string.Empty;
        public decimal Thread { get; set; } = 0;
        public string DeviceID { get; set; } = string.Empty;
        public string TighteningStatus { get; set; } = string.Empty;
        public bool LaserStatus { get; set; } = false;  
        public StatusCountModel StatusCount
        {
            get => new StatusCountModel()
            {
                NG = NG,
                OKALL = OKALL,
                OK = OK,
            };
        }
        public JobSeqModel JobSeq {
            get => new JobSeqModel()
            {
                Job = Job,
                Seq = Seq,
            };
        }
    }
}
