using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Database.Models
{
    public class ConfigLogModel
    {
        public int Log_Id { get; set; } 
        public Guid Uid { get; set; }
        public string Action { get; set; } = string.Empty;
        public DateTime Log_Time { get; set; }
    }
}
