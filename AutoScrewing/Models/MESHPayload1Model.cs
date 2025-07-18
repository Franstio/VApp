using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewing.Models
{
    public class MESHPayload1Model
    {
        public string OperationId { get; set; } // Dari Config 
        public string LotNo { get; set; } = string.Empty; // Scan 2
        public string MaterialLotNo { get; set; } = string.Empty; // Scan 3
        public string WorkOrderNumber { get; set; } = string.Empty;
        public string OperationUserSN { get; set; } = string.Empty; //Scan 1
        public List<DataItem> DataItems { get; set; } = new();
        public string Result { get; set; } = string.Empty;

        public MESHPayload1Model(string operationId,string workId, string operationUserSN,string materialLotNo,string lotNo)
        {
            OperationId = operationId;
            OperationUserSN = operationUserSN;
            WorkOrderNumber = workId;
            LotNo = lotNo;
            MaterialLotNo = materialLotNo;
        }
        public MESHPayload1Model(string operationId,string workId, string operationUserSN, string materialLotNo, string lotNo, string result)
        {
            OperationId = operationId;
            OperationUserSN = operationUserSN;
            WorkOrderNumber = workId;
            LotNo = lotNo;
            MaterialLotNo = materialLotNo;
            Result = result;
        }

        public class DataItem
        {
            public string key { get; set; } = string.Empty;
            public string value { get; set; } = string.Empty;
            public string? lowerValue { get; set; } = null;
            public string? upperValue { get; set;} = null;
            public string? standValue { get; set; } = null;
            public string? unitName { get; set; } = null;
        }

    }
}
