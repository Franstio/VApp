using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Database.Models
{
    public class TransactionModel
    {
        public string Scan_ID { get; set; } = string.Empty;
        public decimal Torque { get; set; } = 0;
        public bool ScrewingResult { get; set; } = false;
        public bool LaserResult { get; set; } = false;
        public bool CameraResult { get; set; } = false;
        public bool Result { get; set; } = false;
        public bool IsError { get; set; } = false;
        public DateTime TransactionTime { get; set; } = DateTime.Now;
    }
}
