using AutoScrewing.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Models
{
    public class OngoingItemModel : TransactionModel
    {
        public DateTime? StartTime { get; set; }
        public DateTime? ScrewStartTime { get; set; }
        public DateTime? ScrewEndTime { get; set; }
        public DateTime? LaserStartTime { get; set; }
        public DateTime? LaserEndTime { get; set; }
        public DateTime? CameraStartTime { get; set; }
        public DateTime? CameraEndTime { get; set; }
        public string CHECKSUM { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public bool isCameraCompleted { get; set; } = false;
        public bool isLaseringCompleted { get; set; } = false;
        public bool isScrewingCompleted { get; set; } = false;
    }
}
