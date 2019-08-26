using System;
using System.Collections.Generic;

namespace FedPayArchiver.EFModels
{
    public partial class ArchHpoSummary
    {
        public string HposPoNo { get; set; }
        public string HposVendorNo { get; set; }
        public string HposContrNo { get; set; }
        public DateTime? HposDateOfOrder { get; set; }
        public string HposFobInd { get; set; }
        public string HposDiscountTerms { get; set; }
        public string HposTDCode { get; set; }
        public string HposSignalCode { get; set; }
        public string HposFundCode { get; set; }
        public string HposBoac { get; set; }
        public string HposConsignee { get; set; }
        public string HposAgencyBureauCode { get; set; }
        public string HposStateCityCode { get; set; }
        public string HposContrOfficerName { get; set; }
        public string HposContrOfficePhone { get; set; }
        public string HposContrAdminRegion { get; set; }
        public string HposProjectCode { get; set; }
        public string HposCrpPoe { get; set; }
        public string HposDistributionCode { get; set; }
        public string HposSdfCode { get; set; }
        public string HposDsdfCode { get; set; }
        public string HposEDInd { get; set; }
        public string HposSpecialInd { get; set; }
        public string HposAmendmentNo { get; set; }
        public string HposStatus { get; set; }
        public DateTime? HposAmendmentDate { get; set; }
        public string HposExceptions { get; set; }
        public DateTime? HposDateClosed { get; set; }
        public string HposHistoryCntr { get; set; }
        public string HposVendorAltKey { get; set; }
        public string HposDunsNo { get; set; }
        public string HposTinNo { get; set; }
        public string HposNotesCodes1 { get; set; }
        public string HposNotesCodes2 { get; set; }
        public string HposNotesCodes3 { get; set; }
        public string HposNotesCodes4 { get; set; }
        public string HposNotesCodes5 { get; set; }
        public decimal? HposValue { get; set; }
        public string HposFssPoNo { get; set; }
        public string HposMoneyOnlyInd { get; set; }
        public string HposDunsp4No { get; set; }
        public string HposCcInd { get; set; }
        public string HposPoId { get; set; }
    }
}
