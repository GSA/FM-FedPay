using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHreceiptActivity
    {
        public string HreaPoNo { get; set; }
        public string HreaStockNo { get; set; }
        public decimal HreaDtlSeqNo { get; set; }
        public decimal HreaSeqNo { get; set; }
        public decimal? HreaPaidUcp { get; set; }
        public decimal? HreaPaidQty { get; set; }
        public string HreaInvoiceNo { get; set; }
        public DateTime? HreaMatchedDate { get; set; }
        public string HreaTypeAction { get; set; }
        public string HreaInitials { get; set; }
        public int HreaId { get; set; }
        public string HreaPoId { get; set; }
    }
}
