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

        public MESHPayload1Model(string operationId,string workId, string operationUserSN,string lotNo,string materialLotNo)
        {
            OperationId = operationId;
            OperationUserSN = operationUserSN;
            WorkOrderNumber = workId;
            LotNo = lotNo;
            MaterialLotNo = materialLotNo;
        }
        public MESHPayload1Model(string operationId,string workId, string operationUserSN, string lotNo, string materialLotNo,string result)
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
            public string Id { get; set; } = string.Empty;
            public string OperationId { get; set; }  = string.Empty;
            public Operation Operation { get; set; } = new();
            public int Index { get; set; }
            public int RowNo { get; set; }
            public string StandValue { get; set; } = string.Empty;
            public string DefaultValue { get; set; } = string.Empty;
            public string LowerValue { get; set; } = string.Empty;
            public string UpperValue { get; set; } = string.Empty;
            public string OperationDataItemId { get; set; } = string.Empty;
            public string Key { get; set; } = string.Empty;
            public string SubKey { get; set; } = string.Empty;
            public int DataType { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string UnitName { get; set; } = string.Empty;
            public string Remark { get; set; } = string.Empty;
            public string DataSource { get; set; } = string.Empty;
            public string WorkOrderId { get; set; }  = string.Empty;
            public string ValueRule { get; set; } = string.Empty;
            public bool UniqueCheck { get; set; }
            public bool SetToLot { get; set; }
            public string Arithmetic { get; set; } = string.Empty;
            public bool CreateSubLot { get; set; }
            public bool CheckSubLot { get; set; }
            public string AttachmentUrl { get; set; } = string.Empty;
            public string WorkstationId { get; set; } = string.Empty;
            public Workstation Workstation { get; set; } = new();
            public string Value { get; set; } = string.Empty;
        }

        public class Operation
        {
            public string Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Path { get; set; } = string.Empty;
            public string Type { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public bool SystemDefault { get; set; }
            public string GroupId { get; set; } = string.Empty;
            public string FailControlType { get; set; } = string.Empty;
            public string CSharpScript { get; set; } = string.Empty;
            public int Level { get; set; }
            public bool FailWhileSkip { get; set; }
            public bool NeedBindTerminal { get; set; }
            public bool Enable { get; set; }
            public string Code { get; set; } = string.Empty;
            public string ErpOperationCode { get; set; } = string.Empty;
        }

        public class Workstation
        {
            public string Id { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Code { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
        }
    }
}
