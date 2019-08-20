using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHinvoiceSummary
    {
        public string HinsInvoiceNo { get; set; }
        public string HinsPoNo { get; set; }
        public string HinsVendorNo { get; set; }
        public string HinsScheduleNo { get; set; }
        public decimal? HinsScheduleCheckSeq { get; set; }
        public string HinsCheckNo { get; set; }
        public DateTime? HinsCheckDate { get; set; }
        public string HinsBatchNo { get; set; }
        public string HinsSubBatchNo { get; set; }
        public string HinsSubBatchSeq { get; set; }
        public string HinsDiscountTerms { get; set; }
        public decimal HinsInvoiceAmt { get; set; }
        public decimal HinsAmtPaid { get; set; }
        public decimal? HinsNonMerchAmt { get; set; }
        public DateTime? HinsInvoiceDate { get; set; }
        public DateTime? HinsDateReceived { get; set; }
        public DateTime? HinsDateKeyedIp { get; set; }
        public string HinsInitialsIp { get; set; }
        public DateTime? HinsDateKeyedPv { get; set; }
        public string HinsInitialsPv { get; set; }
        public DateTime? HinsRecDateReceived { get; set; }
        public string HinsFundCode { get; set; }
        public string HinsInvoiceStatus { get; set; }
        public string HinsFederalInd { get; set; }
        public string HinsNetDays { get; set; }
        public string HinsAdjustInd { get; set; }
        public string HinsActionCode { get; set; }
        public string HinsInterestCode { get; set; }
        public decimal? HinsInterestAmt { get; set; }
        public string HinsDiscountELCode { get; set; }
        public decimal? HinsDiscountELAmt { get; set; }
        public decimal? HinsAdminDiffAmt { get; set; }
        public string HinsScheduleDate { get; set; }
        public string HinsDocumentNo { get; set; }
        public string HinsTreasMonth { get; set; }
        public string HinsFssPoNo { get; set; }
        public string HinsInternetInd { get; set; }
        public string HinsPegDocNo { get; set; }
        public DateTime? HinsInitTimestamp { get; set; }
        public string HinsSourceFile { get; set; }
        public decimal? HinsCycleNo { get; set; }
        public DateTime? HinsDeleteDate { get; set; }
        public int HinsId { get; set; }
        public string HinsPoId { get; set; }
    }
}
