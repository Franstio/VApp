using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Database.Models
{
    public class LogModel
    {
        
        public int log_id { get; set; }
        public DateTime record_time { get; set; }
        public string log_type { get; set; } = string.Empty;
        public string source { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string status { get;set; } = string.Empty;
        public string payload { get; set; } = string.Empty; 
        public string result { get; set; } = string.Empty;
        public LogModel()
        {

        }
        public LogModel(DateTime RecordDate,string LogType,string Source,string Description,string Status)
        {
            record_time = RecordDate;
            log_type = LogType;
            this.source = Source;
            this.description = Description;
            this.status = Status;
        }
        public LogModel( string LogType, string Source, string Description, string Status)
        {
            record_time = DateTime.Now;
            log_type = LogType;
            this.source = Source;
            this.description = Description;
            this.status = Status;
        }
    }
}
