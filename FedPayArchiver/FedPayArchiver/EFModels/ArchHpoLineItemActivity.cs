using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHpoLineItemActivity
    {
        public string HpoaPoNo { get; set; }
        public decimal HpoaPolSeqNo { get; set; }
        public decimal HpoaSeqNo { get; set; }
        public string HpoaTypeAction { get; set; }
        public decimal HpoaPaidQty { get; set; }
        public string HpoaInvoiceNo { get; set; }
        public DateTime? HpoaPaidDate { get; set; }
        public decimal HpoaPaidUcp { get; set; }
        public decimal? HpoaBilledUsp { get; set; }
        public string HpoaFssPoNo { get; set; }
        public decimal? HpoaBilledAmt { get; set; }
        public decimal? HpoaTotalBill { get; set; }
        public decimal? HpoaAmtAvailable { get; set; }
        public decimal? HpoaPaidAmt { get; set; }
        public DateTime? HpoaDeleteDate { get; set; }
        public string HpoaPoId { get; set; }
    }
}
