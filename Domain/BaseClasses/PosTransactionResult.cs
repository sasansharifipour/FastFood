using PosInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.BaseClasses
{
    public class PosTransactionResult : ILogicalDeleteable
    {
        public int ID { get; set; } = 0;

        public int OrderID { get; set; } = 0;

        public bool Deleted { get; set; } = false;

        public DateTime SoftwareExecutionTime { get; set; }

        public Enums.TransactionType TranType { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMsg { get; set; }

        public string PaymentAmount { get; set; }

        public string RRN { get; set; }

        public string Stan { get; set; }

        public string DateTime { get; set; }

        public string MerchantId { get; set; }

        public string TerminalId { get; set; }

        public string CardNumber { get; set; }

        public string MessageId { get; set; }
    }
}
