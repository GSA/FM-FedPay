using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHinvoiceLineItem
    {
        public string HinlInvoiceNo { get; set; }
        public string HinlPoNo { get; set; }
        public decimal HinlSeqNo { get; set; }
        public string HinlNonMerchCode { get; set; }
        public string HinlReqNo { get; set; }
        public string HinlStockNo { get; set; }
        public decimal? HinlQty { get; set; }
        public decimal HinlLineItemAmt { get; set; }
        public string HinlPaymentInd { get; set; }
        public string HinlTypeAction { get; set; }
        public string HinlOpenItem { get; set; }
        public decimal? HinlPaidUcp { get; set; }
        public string HinlFssPoNo { get; set; }
        public decimal? HinlPolSeqNo { get; set; }
        public string HinlNmOdesc { get; set; }
        public decimal? HinlVqty { get; set; }
        public decimal? HinlVamt { get; set; }
        public decimal? HinlDisbursedUcp { get; set; }
        public decimal? HinlDisbursedUsp { get; set; }
        public decimal? HinlDisbursedQty { get; set; }
        public string HinlInvoiceStatus { get; set; }
        public DateTime? HinlInitTimestamp { get; set; }
        public string HinlSourceFile { get; set; }
        public decimal? HinlCycleNo { get; set; }
        public decimal? HinlCycleRecNo { get; set; }
        public int HinlId { get; set; }
        public string HinlPoId { get; set; }
    }
}
