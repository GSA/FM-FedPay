using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHreceiptDetail
    {
        public string HredPoNo { get; set; }
        public string HredStockNo { get; set; }
        public decimal? HredQty { get; set; }
        public decimal? HredMarkChg { get; set; }
        public decimal? HredUcp { get; set; }
        public string HredUnitOfIssue { get; set; }
        public DateTime? HredDateReceived { get; set; }
        public DateTime? HredDateAdded { get; set; }
        public string HredGblNo { get; set; }
        public string HredReceiptInd { get; set; }
        public string HredInitials { get; set; }
        public string HredPegDocNo { get; set; }
        public string HredFssPoNo { get; set; }
        public string HredInvoiceNo { get; set; }
        public string HredTypeAction { get; set; }
        public string HredSource { get; set; }
        public string HredSourceFile { get; set; }
        public int HredId { get; set; }
        public string HredPoId { get; set; }
    }
}
