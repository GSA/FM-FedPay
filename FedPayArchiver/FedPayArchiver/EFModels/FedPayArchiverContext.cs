using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FedPayArchiver.EFModels
{
    public partial class fedpayArhiverContext : DbContext
    {
        public fedpayArhiverContext()
        {
        }

        public fedpayArhiverContext(DbContextOptions<fedpayArhiverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArchHadminDiff> ArchHadminDiff { get; set; }
        public virtual DbSet<ArchHinvoiceLineItem> ArchHinvoiceLineItem { get; set; }
        public virtual DbSet<ArchHinvoiceReturnNotice> ArchHinvoiceReturnNotice { get; set; }
        public virtual DbSet<ArchHinvoiceSummary> ArchHinvoiceSummary { get; set; }
        public virtual DbSet<ArchHpoLineItem> ArchHpoLineItem { get; set; }
        public virtual DbSet<ArchHpoLineItemActivity> ArchHpoLineItemActivity { get; set; }
        public virtual DbSet<ArchHpoNote> ArchHpoNote { get; set; }
        public virtual DbSet<ArchHpoSummary> ArchHpoSummary { get; set; }
        public virtual DbSet<ArchHreceiptActivity> ArchHreceiptActivity { get; set; }
        public virtual DbSet<ArchHreceiptDetail> ArchHreceiptDetail { get; set; }
        public virtual DbSet<ArchHreceiptSummary> ArchHreceiptSummary { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Startup.Configuration["ConnectionString:FedPay"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchHadminDiff>(entity =>
            {
                entity.HasKey(e => new { e.HaddPoId, e.HaddId });

                entity.ToTable("arch_hadmin_diff", "fedpay_arch");

                entity.HasIndex(e => e.HaddFssPoNo)
                    .HasName("locate_arch_hadmin_diff_5");

                entity.HasIndex(e => e.HaddPoNo)
                    .HasName("locate_arch_hadmin_diff");

                entity.HasIndex(e => e.HaddVendorNo)
                    .HasName("locate_arch_hadmin_diff_3");

                entity.HasIndex(e => new { e.HaddInvoiceNo, e.HaddPoNo, e.HaddSeqNo })
                    .HasName("locate_arch_hadmin_diff_1");

                entity.HasIndex(e => new { e.HaddPoNo, e.HaddInvoiceNo, e.HaddSeqNo })
                    .HasName("locate_arch_hadmin_diff_2");

                entity.Property(e => e.HaddPoId)
                    .HasColumnName("hadd_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HaddId)
                    .HasColumnName("hadd_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HaddAmt)
                    .HasColumnName("hadd_amt")
                    .HasColumnType("numeric(12,2)");

                entity.Property(e => e.HaddBilledQty)
                    .HasColumnName("hadd_billed_qty")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HaddBilledUcp)
                    .HasColumnName("hadd_billed_ucp")
                    .HasColumnType("numeric(13,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HaddCbNo)
                    .HasColumnName("hadd_cb_no")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddClaimControlNo)
                    .HasColumnName("hadd_claim_control_no")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddCurrentInd)
                    .HasColumnName("hadd_current_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddCycleNo)
                    .HasColumnName("hadd_cycle_no")
                    .HasColumnType("numeric(8,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HaddCycleRecNo)
                    .HasColumnName("hadd_cycle_rec_no")
                    .HasColumnType("numeric(10,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HaddDateOfDiff)
                    .HasColumnName("hadd_date_of_diff")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HaddErrorCd)
                    .HasColumnName("hadd_error_cd")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddFssPoNo)
                    .HasColumnName("hadd_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddGblNo)
                    .HasColumnName("hadd_gbl_no")
                    .HasMaxLength(14)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddInitTimestamp)
                    .HasColumnName("hadd_init_timestamp")
                    .HasColumnType("timestamp(6) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HaddInitials)
                    .HasColumnName("hadd_initials")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddInvoiceNo)
                    .IsRequired()
                    .HasColumnName("hadd_invoice_no")
                    .HasMaxLength(12);

                entity.Property(e => e.HaddNonMerchCode)
                    .HasColumnName("hadd_non_merch_code")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddPegDocNo)
                    .HasColumnName("hadd_peg_doc_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddPoNo)
                    .IsRequired()
                    .HasColumnName("hadd_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HaddPoQty)
                    .HasColumnName("hadd_po_qty")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HaddPoUcp)
                    .HasColumnName("hadd_po_ucp")
                    .HasColumnType("numeric(13,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HaddPolSeqNo)
                    .HasColumnName("hadd_pol_seq_no")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HaddSeqNo)
                    .HasColumnName("hadd_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HaddSourceFile)
                    .HasColumnName("hadd_source_file")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddStockNo)
                    .HasColumnName("hadd_stock_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HaddVendorNo)
                    .HasColumnName("hadd_vendor_no")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ArchHinvoiceLineItem>(entity =>
            {
                entity.HasKey(e => new { e.HinlPoId, e.HinlId });

                entity.ToTable("arch_hinvoice_line_item", "fedpay_arch");

                entity.HasIndex(e => e.HinlFssPoNo)
                    .HasName("locate_arch_hinvoice_line_3");

                entity.HasIndex(e => e.HinlPoNo)
                    .HasName("locate_arch_hinvoice_line_item");

                entity.HasIndex(e => new { e.HinlInvoiceNo, e.HinlPoNo })
                    .HasName("locate_arch_hinvoice_line_1");

                entity.HasIndex(e => new { e.HinlInvoiceNo, e.HinlPoNo, e.HinlSeqNo })
                    .HasName("locate_arch_hinvoice_line");

                entity.Property(e => e.HinlPoId)
                    .HasColumnName("hinl_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HinlId)
                    .HasColumnName("hinl_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HinlCycleNo)
                    .HasColumnName("hinl_cycle_no")
                    .HasColumnType("numeric(8,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlCycleRecNo)
                    .HasColumnName("hinl_cycle_rec_no")
                    .HasColumnType("numeric(10,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlDisbursedQty)
                    .HasColumnName("hinl_disbursed_qty")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlDisbursedUcp)
                    .HasColumnName("hinl_disbursed_ucp")
                    .HasColumnType("numeric(13,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlDisbursedUsp)
                    .HasColumnName("hinl_disbursed_usp")
                    .HasColumnType("numeric(10,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlFssPoNo)
                    .HasColumnName("hinl_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlInitTimestamp)
                    .HasColumnName("hinl_init_timestamp")
                    .HasColumnType("timestamp(6) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinlInvoiceNo)
                    .HasColumnName("hinl_invoice_no")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlInvoiceStatus)
                    .HasColumnName("hinl_invoice_status")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlLineItemAmt)
                    .HasColumnName("hinl_line_item_amt")
                    .HasColumnType("numeric(12,2)");

                entity.Property(e => e.HinlNmOdesc)
                    .HasColumnName("hinl_nm_odesc")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlNonMerchCode)
                    .HasColumnName("hinl_non_merch_code")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlOpenItem)
                    .HasColumnName("hinl_open_item")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlPaidUcp)
                    .HasColumnName("hinl_paid_ucp")
                    .HasColumnType("numeric(13,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlPaymentInd)
                    .HasColumnName("hinl_payment_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlPoNo)
                    .IsRequired()
                    .HasColumnName("hinl_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HinlPolSeqNo)
                    .HasColumnName("hinl_pol_seq_no")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlQty)
                    .HasColumnName("hinl_qty")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlReqNo)
                    .HasColumnName("hinl_req_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlSeqNo)
                    .HasColumnName("hinl_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HinlSourceFile)
                    .HasColumnName("hinl_source_file")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlStockNo)
                    .HasColumnName("hinl_stock_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlTypeAction)
                    .HasColumnName("hinl_type_action")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinlVamt)
                    .HasColumnName("hinl_vamt")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinlVqty)
                    .HasColumnName("hinl_vqty")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");
            });

            modelBuilder.Entity<ArchHinvoiceReturnNotice>(entity =>
            {
                entity.HasKey(e => new { e.HirnPoId, e.HirnId });

                entity.ToTable("arch_hinvoice_return_notice", "fedpay_arch");

                entity.HasIndex(e => e.HirnFssPoNo)
                    .HasName("locate_arch_hirn_4");

                entity.HasIndex(e => e.HirnPoNo)
                    .HasName("l_arch_hinvoice_return_notice");

                entity.HasIndex(e => e.HirnVendorNo)
                    .HasName("locate_arch_hirn_3");

                entity.HasIndex(e => new { e.HirnInvoiceNo, e.HirnPoNo })
                    .HasName("locate_arch_hirn_1");

                entity.HasIndex(e => new { e.HirnPoNo, e.HirnInvoiceNo })
                    .HasName("locate_arch_hirn_2");

                entity.Property(e => e.HirnPoId)
                    .HasColumnName("hirn_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HirnId)
                    .HasColumnName("hirn_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HirnCbNo)
                    .HasColumnName("hirn_cb_no")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnCurrentInd)
                    .HasColumnName("hirn_current_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnCycleNo)
                    .HasColumnName("hirn_cycle_no")
                    .HasColumnType("numeric(8,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HirnCycleRecNo)
                    .HasColumnName("hirn_cycle_rec_no")
                    .HasColumnType("numeric(10,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HirnDateOfReturn)
                    .HasColumnName("hirn_date_of_return")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HirnDateReceived)
                    .HasColumnName("hirn_date_received")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HirnFssPoNo)
                    .HasColumnName("hirn_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnInitTimestamp)
                    .HasColumnName("hirn_init_timestamp")
                    .HasColumnType("timestamp(6) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HirnInitials)
                    .HasColumnName("hirn_initials")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnInvoiceNo)
                    .HasColumnName("hirn_invoice_no")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnInvoiceReturnCode1)
                    .HasColumnName("hirn_invoice_return_code1")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnInvoiceReturnCode2)
                    .HasColumnName("hirn_invoice_return_code2")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnInvoiceReturnCode3)
                    .HasColumnName("hirn_invoice_return_code3")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnInvoiceReturnCode4)
                    .HasColumnName("hirn_invoice_return_code4")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnInvoiceReturnCode5)
                    .HasColumnName("hirn_invoice_return_code5")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnPegDocNo)
                    .HasColumnName("hirn_peg_doc_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnPoNo)
                    .HasColumnName("hirn_po_no")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnReturnAmt)
                    .HasColumnName("hirn_return_amt")
                    .HasColumnType("numeric(12,2)");

                entity.Property(e => e.HirnSourceFile)
                    .HasColumnName("hirn_source_file")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnVendorAltKey)
                    .HasColumnName("hirn_vendor_alt_key")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HirnVendorNo)
                    .HasColumnName("hirn_vendor_no")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ArchHinvoiceSummary>(entity =>
            {
                entity.HasKey(e => new { e.HinsPoId, e.HinsId });

                entity.ToTable("arch_hinvoice_summary", "fedpay_arch");

                entity.HasIndex(e => e.HinsCheckNo)
                    .HasName("locate_arch_hinvoice_5");

                entity.HasIndex(e => e.HinsFssPoNo)
                    .HasName("locate_arch_hinvoice_6");

                entity.HasIndex(e => e.HinsInvoiceDate)
                    .HasName("locate_arch_hinvoice_7");

                entity.HasIndex(e => e.HinsPegDocNo)
                    .HasName("locate_arch_hins_peg_doc_no");

                entity.HasIndex(e => e.HinsPoNo)
                    .HasName("locate_arch_hinvoice_summary");

                entity.HasIndex(e => e.HinsVendorNo)
                    .HasName("locate_arch_hinvoice_3");

                entity.Property(e => e.HinsPoId)
                    .HasColumnName("hins_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HinsId)
                    .HasColumnName("hins_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HinsActionCode)
                    .HasColumnName("hins_action_code")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsAdjustInd)
                    .HasColumnName("hins_adjust_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsAdminDiffAmt)
                    .HasColumnName("hins_admin_diff_amt")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinsAmtPaid)
                    .HasColumnName("hins_amt_paid")
                    .HasColumnType("numeric(12,2)");

                entity.Property(e => e.HinsBatchNo)
                    .HasColumnName("hins_batch_no")
                    .HasMaxLength(13)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsCheckDate)
                    .HasColumnName("hins_check_date")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsCheckNo)
                    .HasColumnName("hins_check_no")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsCycleNo)
                    .HasColumnName("hins_cycle_no")
                    .HasColumnType("numeric(8,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinsDateKeyedIp)
                    .HasColumnName("hins_date_keyed_ip")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsDateKeyedPv)
                    .HasColumnName("hins_date_keyed_pv")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsDateReceived)
                    .HasColumnName("hins_date_received")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsDeleteDate)
                    .HasColumnName("hins_delete_date")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsDiscountELAmt)
                    .HasColumnName("hins_discount_e_l_amt")
                    .HasColumnType("numeric(8,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinsDiscountELCode)
                    .HasColumnName("hins_discount_e_l_code")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsDiscountTerms)
                    .HasColumnName("hins_discount_terms")
                    .HasMaxLength(7)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsDocumentNo)
                    .HasColumnName("hins_document_no")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsFederalInd)
                    .HasColumnName("hins_federal_ind")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsFssPoNo)
                    .HasColumnName("hins_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsFundCode)
                    .HasColumnName("hins_fund_code")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsInitTimestamp)
                    .HasColumnName("hins_init_timestamp")
                    .HasColumnType("timestamp(6) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsInitialsIp)
                    .HasColumnName("hins_initials_ip")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsInitialsPv)
                    .HasColumnName("hins_initials_pv")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsInterestAmt)
                    .HasColumnName("hins_interest_amt")
                    .HasColumnType("numeric(8,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinsInterestCode)
                    .HasColumnName("hins_interest_code")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsInternetInd)
                    .HasColumnName("hins_internet_ind")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsInvoiceAmt)
                    .HasColumnName("hins_invoice_amt")
                    .HasColumnType("numeric(12,2)");

                entity.Property(e => e.HinsInvoiceDate)
                    .HasColumnName("hins_invoice_date")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsInvoiceNo)
                    .IsRequired()
                    .HasColumnName("hins_invoice_no")
                    .HasMaxLength(12);

                entity.Property(e => e.HinsInvoiceStatus)
                    .HasColumnName("hins_invoice_status")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsNetDays)
                    .HasColumnName("hins_net_days")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsNonMerchAmt)
                    .HasColumnName("hins_non_merch_amt")
                    .HasColumnType("numeric(8,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinsPegDocNo)
                    .HasColumnName("hins_peg_doc_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsPoNo)
                    .IsRequired()
                    .HasColumnName("hins_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HinsRecDateReceived)
                    .HasColumnName("hins_rec_date_received")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HinsScheduleCheckSeq)
                    .HasColumnName("hins_schedule_check_seq")
                    .HasColumnType("numeric(5,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HinsScheduleDate)
                    .HasColumnName("hins_schedule_date")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsScheduleNo)
                    .HasColumnName("hins_schedule_no")
                    .HasMaxLength(14)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsSourceFile)
                    .HasColumnName("hins_source_file")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsSubBatchNo)
                    .HasColumnName("hins_sub_batch_no")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsSubBatchSeq)
                    .HasColumnName("hins_sub_batch_seq")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsTreasMonth)
                    .HasColumnName("hins_treas_month")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HinsVendorNo)
                    .HasColumnName("hins_vendor_no")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ArchHpoLineItem>(entity =>
            {
                entity.HasKey(e => new { e.HpolPoId, e.HpolSeqNo });

                entity.ToTable("arch_hpo_line_item", "fedpay_arch");

                entity.HasIndex(e => e.HpolFssPoNo)
                    .HasName("locate_arch_hpo_line_item_3");

                entity.HasIndex(e => e.HpolPoNo)
                    .HasName("locate_arch_hpo_line_item");

                entity.HasIndex(e => e.HpolReqNo)
                    .HasName("locate_arch_hpo_line_item_4");

                entity.HasIndex(e => e.HpolStockNo)
                    .HasName("locate_arch_hpo_line_item_5");

                entity.Property(e => e.HpolPoId)
                    .HasColumnName("hpol_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HpolSeqNo)
                    .HasColumnName("hpol_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HpolAmt)
                    .HasColumnName("hpol_amt")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpolAmtAvailable)
                    .HasColumnName("hpol_amt_available")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpolCustomerData)
                    .HasColumnName("hpol_customer_data")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolFssPoNo)
                    .HasColumnName("hpol_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolLevelIiiData)
                    .HasColumnName("hpol_level_iii_data")
                    .HasMaxLength(25)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolMuPercent)
                    .HasColumnName("hpol_mu_percent")
                    .HasColumnType("numeric(7,5)")
                    .HasDefaultValueSql("NULL::numeric")
                    .ForNpgsqlHasComment("Added per Bob Warder to match po_line_item table 2/24/04 arh");

                entity.Property(e => e.HpolOpenBillAmt)
                    .HasColumnName("hpol_open_bill_amt")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpolPoNo)
                    .IsRequired()
                    .HasColumnName("hpol_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HpolQty)
                    .HasColumnName("hpol_qty")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HpolQtyAvailable)
                    .HasColumnName("hpol_qty_available")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HpolReqNo)
                    .HasColumnName("hpol_req_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolSpecialRate)
                    .HasColumnName("hpol_special_rate")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolSpecialRateCharged)
                    .HasColumnName("hpol_special_rate_charged")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolStockNo)
                    .HasColumnName("hpol_stock_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolSupplAddress)
                    .HasColumnName("hpol_suppl_address")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolTotalBill)
                    .HasColumnName("hpol_total_bill")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpolUcp)
                    .HasColumnName("hpol_ucp")
                    .HasColumnType("numeric(13,5)");

                entity.Property(e => e.HpolUnitOfIssue)
                    .HasColumnName("hpol_unit_of_issue")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpolUsp)
                    .HasColumnName("hpol_usp")
                    .HasColumnType("numeric(10,2)");
            });

            modelBuilder.Entity<ArchHpoLineItemActivity>(entity =>
            {
                entity.HasKey(e => new { e.HpoaPoId, e.HpoaPolSeqNo, e.HpoaSeqNo });

                entity.ToTable("arch_hpo_line_item_activity", "fedpay_arch");

                entity.HasIndex(e => e.HpoaFssPoNo)
                    .HasName("l_arch_hpo_line_activity_4");

                entity.HasIndex(e => e.HpoaPoNo)
                    .HasName("l_arch_hpo_line_item_activity");

                entity.HasIndex(e => new { e.HpoaPoNo, e.HpoaPolSeqNo })
                    .HasName("l_arch_hpo_line_activity_2");

                entity.Property(e => e.HpoaPoId)
                    .HasColumnName("hpoa_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HpoaPolSeqNo)
                    .HasColumnName("hpoa_pol_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HpoaSeqNo)
                    .HasColumnName("hpoa_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HpoaAmtAvailable)
                    .HasColumnName("hpoa_amt_available")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpoaBilledAmt)
                    .HasColumnName("hpoa_billed_amt")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpoaBilledUsp)
                    .HasColumnName("hpoa_billed_usp")
                    .HasColumnType("numeric(8,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpoaDeleteDate)
                    .HasColumnName("hpoa_delete_date")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HpoaFssPoNo)
                    .HasColumnName("hpoa_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpoaInvoiceNo)
                    .HasColumnName("hpoa_invoice_no")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HpoaPaidAmt)
                    .HasColumnName("hpoa_paid_amt")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpoaPaidDate)
                    .HasColumnName("hpoa_paid_date")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HpoaPaidQty)
                    .HasColumnName("hpoa_paid_qty")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HpoaPaidUcp)
                    .HasColumnName("hpoa_paid_ucp")
                    .HasColumnType("numeric(11,4)");

                entity.Property(e => e.HpoaPoNo)
                    .IsRequired()
                    .HasColumnName("hpoa_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HpoaTotalBill)
                    .HasColumnName("hpoa_total_bill")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HpoaTypeAction)
                    .HasColumnName("hpoa_type_action")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ArchHpoNote>(entity =>
            {
                entity.HasKey(e => new { e.HponPoId, e.HponSeqNo });

                entity.ToTable("arch_hpo_note", "fedpay_arch");

                entity.HasIndex(e => e.HponFssPoNo)
                    .HasName("locate_arch_hpo_note_2");

                entity.HasIndex(e => e.HponPoNo)
                    .HasName("locate_arch_hpo_note");

                entity.Property(e => e.HponPoId)
                    .HasColumnName("hpon_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HponSeqNo)
                    .HasColumnName("hpon_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HponFssPoNo)
                    .HasColumnName("hpon_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HponNoteAddendums)
                    .HasColumnName("hpon_note_addendums")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HponPoNo)
                    .IsRequired()
                    .HasColumnName("hpon_po_no")
                    .HasMaxLength(9);
            });

            modelBuilder.Entity<ArchHpoSummary>(entity =>
            {
                entity.HasKey(e => e.HposPoId);

                entity.ToTable("arch_hpo_summary", "fedpay_arch");

                entity.HasIndex(e => e.HposContrNo)
                    .HasName("locate_arch_hpo_summary_2");

                entity.HasIndex(e => e.HposFssPoNo)
                    .HasName("locate_arch_hpo_summary_4");

                entity.HasIndex(e => e.HposMoneyOnlyInd)
                    .HasName("locate_arch_hpo_summary_5");

                entity.HasIndex(e => e.HposPoNo)
                    .HasName("locate_arch_hpo_summary");

                entity.HasIndex(e => e.HposVendorNo)
                    .HasName("locate_arch_hpo_summary_3");

                entity.Property(e => e.HposPoId)
                    .HasColumnName("hpos_po_id")
                    .HasMaxLength(15)
                    .ValueGeneratedNever();

                entity.Property(e => e.HposAgencyBureauCode)
                    .HasColumnName("hpos_agency_bureau_code")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposAmendmentDate)
                    .HasColumnName("hpos_amendment_date")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HposAmendmentNo)
                    .HasColumnName("hpos_amendment_no")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposBoac)
                    .HasColumnName("hpos_boac")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposCcInd)
                    .HasColumnName("hpos_cc_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying")
                    .ForNpgsqlHasComment("INDICATES IF PURCHASE IS BEING MADE VIA CREDIT CARD");

                entity.Property(e => e.HposConsignee)
                    .HasColumnName("hpos_consignee")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposContrAdminRegion)
                    .HasColumnName("hpos_contr_admin_region")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposContrNo)
                    .HasColumnName("hpos_contr_no")
                    .HasMaxLength(18)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposContrOfficePhone)
                    .HasColumnName("hpos_contr_office_phone")
                    .HasMaxLength(16)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposContrOfficerName)
                    .HasColumnName("hpos_contr_officer_name")
                    .HasMaxLength(24)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposCrpPoe)
                    .HasColumnName("hpos_crp_poe")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposDateClosed)
                    .HasColumnName("hpos_date_closed")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HposDateOfOrder)
                    .HasColumnName("hpos_date_of_order")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HposDiscountTerms)
                    .HasColumnName("hpos_discount_terms")
                    .HasMaxLength(28)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposDistributionCode)
                    .HasColumnName("hpos_distribution_code")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposDsdfCode)
                    .HasColumnName("hpos_dsdf_code")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposDunsNo)
                    .HasColumnName("hpos_duns_no")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposDunsp4No)
                    .HasColumnName("hpos_dunsp4_no")
                    .HasMaxLength(4)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposEDInd)
                    .HasColumnName("hpos_e_d_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposExceptions)
                    .HasColumnName("hpos_exceptions")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposFobInd)
                    .HasColumnName("hpos_fob_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposFssPoNo)
                    .HasColumnName("hpos_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposFundCode)
                    .HasColumnName("hpos_fund_code")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposHistoryCntr)
                    .HasColumnName("hpos_history_cntr")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposMoneyOnlyInd)
                    .HasColumnName("hpos_money_only_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposNotesCodes1)
                    .HasColumnName("hpos_notes_codes1")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposNotesCodes2)
                    .HasColumnName("hpos_notes_codes2")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposNotesCodes3)
                    .HasColumnName("hpos_notes_codes3")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposNotesCodes4)
                    .HasColumnName("hpos_notes_codes4")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposNotesCodes5)
                    .HasColumnName("hpos_notes_codes5")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposPoNo)
                    .IsRequired()
                    .HasColumnName("hpos_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HposProjectCode)
                    .HasColumnName("hpos_project_code")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposSdfCode)
                    .HasColumnName("hpos_sdf_code")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposSignalCode)
                    .HasColumnName("hpos_signal_code")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposSpecialInd)
                    .HasColumnName("hpos_special_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposStateCityCode)
                    .HasColumnName("hpos_state_city_code")
                    .HasMaxLength(6)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposStatus)
                    .HasColumnName("hpos_status")
                    .HasMaxLength(5)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposTDCode)
                    .HasColumnName("hpos_t_d_code")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposTinNo)
                    .HasColumnName("hpos_tin_no")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposValue)
                    .HasColumnName("hpos_value")
                    .HasColumnType("numeric(12,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HposVendorAltKey)
                    .HasColumnName("hpos_vendor_alt_key")
                    .HasMaxLength(30)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HposVendorNo)
                    .HasColumnName("hpos_vendor_no")
                    .HasMaxLength(9)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ArchHreceiptActivity>(entity =>
            {
                entity.HasKey(e => new { e.HreaPoId, e.HreaId });

                entity.ToTable("arch_hreceipt_activity", "fedpay_arch");

                entity.HasIndex(e => e.HreaPoNo)
                    .HasName("l_arch_hreceipt_activity_1");

                entity.HasIndex(e => new { e.HreaPoNo, e.HreaStockNo, e.HreaDtlSeqNo, e.HreaSeqNo })
                    .HasName("l_arch_hreceipt_activity");

                entity.Property(e => e.HreaPoId)
                    .HasColumnName("hrea_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HreaId)
                    .HasColumnName("hrea_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HreaDtlSeqNo)
                    .HasColumnName("hrea_dtl_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HreaInitials)
                    .HasColumnName("hrea_initials")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HreaInvoiceNo)
                    .HasColumnName("hrea_invoice_no")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HreaMatchedDate)
                    .HasColumnName("hrea_matched_date")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HreaPaidQty)
                    .HasColumnName("hrea_paid_qty")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HreaPaidUcp)
                    .HasColumnName("hrea_paid_ucp")
                    .HasColumnType("numeric(11,4)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HreaPoNo)
                    .IsRequired()
                    .HasColumnName("hrea_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HreaSeqNo)
                    .HasColumnName("hrea_seq_no")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HreaStockNo)
                    .IsRequired()
                    .HasColumnName("hrea_stock_no")
                    .HasMaxLength(15);

                entity.Property(e => e.HreaTypeAction)
                    .HasColumnName("hrea_type_action")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ArchHreceiptDetail>(entity =>
            {
                entity.HasKey(e => new { e.HredPoId, e.HredId });

                entity.ToTable("arch_hreceipt_detail", "fedpay_arch");

                entity.HasIndex(e => e.HredPoNo)
                    .HasName("locate_arch_hreceipt_detail");

                entity.HasIndex(e => new { e.HredPoNo, e.HredStockNo })
                    .HasName("l_arch_hreceipt_detail_2");

                entity.Property(e => e.HredPoId)
                    .HasColumnName("hred_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HredId)
                    .HasColumnName("hred_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HredDateAdded)
                    .HasColumnName("hred_date_added")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HredDateReceived)
                    .HasColumnName("hred_date_received")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HredFssPoNo)
                    .HasColumnName("hred_fss_po_no")
                    .HasMaxLength(11)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredGblNo)
                    .HasColumnName("hred_gbl_no")
                    .HasMaxLength(14)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredInitials)
                    .HasColumnName("hred_initials")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredInvoiceNo)
                    .HasColumnName("hred_invoice_no")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredMarkChg)
                    .HasColumnName("hred_mark_chg")
                    .HasColumnType("numeric(8,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HredPegDocNo)
                    .HasColumnName("hred_peg_doc_no")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredPoNo)
                    .IsRequired()
                    .HasColumnName("hred_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HredQty)
                    .HasColumnName("hred_qty")
                    .HasColumnType("numeric(6,0)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HredReceiptInd)
                    .HasColumnName("hred_receipt_ind")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredSource)
                    .HasColumnName("hred_source")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredSourceFile)
                    .HasColumnName("hred_source_file")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredStockNo)
                    .IsRequired()
                    .HasColumnName("hred_stock_no")
                    .HasMaxLength(15);

                entity.Property(e => e.HredTypeAction)
                    .HasColumnName("hred_type_action")
                    .HasMaxLength(1)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HredUcp)
                    .HasColumnName("hred_ucp")
                    .HasColumnType("numeric(13,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HredUnitOfIssue)
                    .HasColumnName("hred_unit_of_issue")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<ArchHreceiptSummary>(entity =>
            {
                entity.HasKey(e => new { e.HresPoId, e.HresId });

                entity.ToTable("arch_hreceipt_summary", "fedpay_arch");

                entity.HasIndex(e => e.HresPoNo)
                    .HasName("locate_arch_hreceipt_summary");

                entity.Property(e => e.HresPoId)
                    .HasColumnName("hres_po_id")
                    .HasMaxLength(15);

                entity.Property(e => e.HresId)
                    .HasColumnName("hres_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.HresClaimControlNo)
                    .HasColumnName("hres_claim_control_no")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("NULL::character varying");

                entity.Property(e => e.HresClaimInd)
                    .HasColumnName("hres_claim_ind")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HresDateClosed)
                    .HasColumnName("hres_date_closed")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HresDateNeg)
                    .HasColumnName("hres_date_neg")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HresDatePos)
                    .HasColumnName("hres_date_pos")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");

                entity.Property(e => e.HresMarkChg)
                    .HasColumnName("hres_mark_chg")
                    .HasColumnType("numeric(8,2)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HresPoNo)
                    .IsRequired()
                    .HasColumnName("hres_po_no")
                    .HasMaxLength(9);

                entity.Property(e => e.HresQty)
                    .HasColumnName("hres_qty")
                    .HasColumnType("numeric(6,0)");

                entity.Property(e => e.HresStockNo)
                    .IsRequired()
                    .HasColumnName("hres_stock_no")
                    .HasMaxLength(15);

                entity.Property(e => e.HresUcp)
                    .HasColumnName("hres_ucp")
                    .HasColumnType("numeric(13,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.HresVendorNote)
                    .HasColumnName("hres_vendor_note")
                    .HasColumnType("timestamp(0) without time zone")
                    .HasDefaultValueSql("NULL::timestamp without time zone");
            });
        }
    }
}
