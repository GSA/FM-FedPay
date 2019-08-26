using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHinvoiceReturnNotice
    {
        public string HirnInvoiceNo { get; set; }
        public string HirnPoNo { get; set; }
        public string HirnVendorNo { get; set; }
        public string HirnVendorAltKey { get; set; }
        public string HirnInvoiceReturnCode1 { get; set; }
        public string HirnInvoiceReturnCode2 { get; set; }
        public string HirnInvoiceReturnCode3 { get; set; }
        public string HirnInvoiceReturnCode4 { get; set; }
        public string HirnInvoiceReturnCode5 { get; set; }
        public decimal HirnReturnAmt { get; set; }
        public DateTime? HirnDateOfReturn { get; set; }
        public DateTime? HirnDateReceived { get; set; }
        public string HirnInitials { get; set; }
        public string HirnCurrentInd { get; set; }
        public string HirnFssPoNo { get; set; }
        public string HirnPegDocNo { get; set; }
        public string HirnCbNo { get; set; }
        public decimal? HirnCycleNo { get; set; }
        public decimal? HirnCycleRecNo { get; set; }
        public string HirnSourceFile { get; set; }
        public DateTime? HirnInitTimestamp { get; set; }
        public int HirnId { get; set; }
        public string HirnPoId { get; set; }
    }
}
