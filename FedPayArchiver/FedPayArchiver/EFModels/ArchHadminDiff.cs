using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHadminDiff
    {
        public string HaddInvoiceNo { get; set; }
        public string HaddPoNo { get; set; }
        public decimal HaddSeqNo { get; set; }
        public string HaddVendorNo { get; set; }
        public string HaddNonMerchCode { get; set; }
        public string HaddStockNo { get; set; }
        public decimal? HaddBilledUcp { get; set; }
        public decimal? HaddBilledQty { get; set; }
        public decimal? HaddPoUcp { get; set; }
        public decimal? HaddPoQty { get; set; }
        public decimal HaddAmt { get; set; }
        public DateTime? HaddDateOfDiff { get; set; }
        public string HaddInitials { get; set; }
        public string HaddCurrentInd { get; set; }
        public string HaddClaimControlNo { get; set; }
        public string HaddFssPoNo { get; set; }
        public decimal? HaddPolSeqNo { get; set; }
        public string HaddCbNo { get; set; }
        public string HaddGblNo { get; set; }
        public string HaddPegDocNo { get; set; }
        public string HaddErrorCd { get; set; }
        public decimal? HaddCycleNo { get; set; }
        public decimal? HaddCycleRecNo { get; set; }
        public string HaddSourceFile { get; set; }
        public DateTime? HaddInitTimestamp { get; set; }
        public int HaddId { get; set; }
        public string HaddPoId { get; set; }
    }
}
