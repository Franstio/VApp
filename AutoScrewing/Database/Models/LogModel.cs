using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Database.Models
{
    public class LogModel
    {
        public int Log_Id { get; set; }
        public DateTime Record_Time { get; set; }
        public string Log_Type { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get;set; } = string.Empty;
        public string Payload { get; set; } = string.Empty; 
        public string Result { get; set; } = string.Empty;

        public LogModel(DateTime RecordDate,string LogType,string Source,string Description,string Status)
        {
            Record_Time = RecordDate;
            Log_Type = LogType;
            this.Source = Source;
            this.Description = Description;
            this.Status = Status;
        }
        public LogModel( string LogType, string Source, string Description, string Status)
        {
            Record_Time = DateTime.Now;
            Log_Type = LogType;
            this.Source = Source;
            this.Description = Description;
            this.Status = Status;
        }
    }
}
