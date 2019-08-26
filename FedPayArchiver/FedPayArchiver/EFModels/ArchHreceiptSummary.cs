using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHreceiptSummary
    {
        public string HresPoNo { get; set; }
        public string HresStockNo { get; set; }
        public decimal? HresUcp { get; set; }
        public decimal HresQty { get; set; }
        public decimal? HresMarkChg { get; set; }
        public DateTime? HresDateClosed { get; set; }
        public DateTime? HresDateNeg { get; set; }
        public DateTime? HresVendorNote { get; set; }
        public DateTime? HresClaimInd { get; set; }
        public string HresClaimControlNo { get; set; }
        public DateTime? HresDatePos { get; set; }
        public int HresId { get; set; }
        public string HresPoId { get; set; }
    }
}
