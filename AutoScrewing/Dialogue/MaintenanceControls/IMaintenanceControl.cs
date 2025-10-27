using AutoScrewing.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Dialogue.MaintenanceControls
{

    public interface IMaintenanceControl
    {
        public record MaintenanceData(string inputText, string outputText, PLCController.PLCItem OutputEnableCommand, PLCController.PLCItem OutputDisableCommand, PLCController.PLCItem InputCommand);
        void ClearTask();
        public MaintenanceData maintenanceData { get;  }
        Task Read();
    }
}
