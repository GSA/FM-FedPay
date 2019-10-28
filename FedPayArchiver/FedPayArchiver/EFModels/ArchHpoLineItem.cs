﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FedPayArchiver.EFModels
{
    public partial class ArchHpoLineItem
    {
        public string HpolPoNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal HpolSeqNo { get; set; }

        public string HpolReqNo { get; set; }
        public string HpolStockNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal HpolQty { get; set; }

        public string HpolUnitOfIssue { get; set; }
        public decimal HpolUcp { get; set; }
        public decimal HpolUsp { get; set; }
        public string HpolSupplAddress { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal HpolQtyAvailable { get; set; }

        public string HpolSpecialRate { get; set; }
        public string HpolSpecialRateCharged { get; set; }
        public string HpolFssPoNo { get; set; }
        public decimal? HpolAmt { get; set; }
        public decimal? HpolAmtAvailable { get; set; }
        public decimal? HpolTotalBill { get; set; }
        public decimal? HpolOpenBillAmt { get; set; }
        public string HpolCustomerData { get; set; }
        public decimal? HpolMuPercent { get; set; }
        public string HpolLevelIiiData { get; set; }
        public string HpolPoId { get; set; }
    }
}
