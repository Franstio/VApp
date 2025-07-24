using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Database.Models
{
    public class TransactionModel
    {
        public string Scan_ID { get; set; } = string.Empty;//LotNo
        public string Scan_ID2 { get; set; } = string.Empty; //MaterialLotNo
        public decimal Torque { get; set; } = 0;
        public bool ScrewingResult { get; set; } = false;
        public bool LaserResult { get; set; } = false;
        public bool CameraResult { get; set; } = false;
        public bool Result { get; set; } = false;
        public bool IsError { get; set; } = false;
        public string FinalResult { get; set; } = string.Empty;
        public string ScrewingTime { get; set; } = string.Empty;
        public decimal ThreadCount { get; set; } = 0;
        public string ErrorDesc { get; set; } = string.Empty;
        public string TighteningStatus { get; set; } = string.Empty;
        public DateTime TransactionTime { get; set; } = DateTime.Now;

        public string OperationUserSN { get; set; } = string.Empty;
        public string OperationId { get; set; } = string.Empty;
        public string WorkNumber { get; set; } = string.Empty;
        public void AddError(string error)
        {
            IsError = true;
            var data = ErrorDesc.Split(',').ToList();
            data.Add(error);
            ErrorDesc = string.Join(",",ErrorDesc);
        }
    }
}
