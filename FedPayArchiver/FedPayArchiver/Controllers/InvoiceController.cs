using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FedPayArchiver.EFModels;

namespace FedPayArchiver.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly fedpaydevContext _context;

        public InvoiceController(fedpaydevContext context)
        {
            _context = context;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArchHinvoiceSummary.ToListAsync());
        }

        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archHinvoiceSummary = await _context.ArchHinvoiceSummary
                .FirstOrDefaultAsync(m => m.HinsPoId == id);
            if (archHinvoiceSummary == null)
            {
                return NotFound();
            }

            return View(archHinvoiceSummary);
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HinsInvoiceNo,HinsPoNo,HinsVendorNo,HinsScheduleNo,HinsScheduleCheckSeq,HinsCheckNo,HinsCheckDate,HinsBatchNo,HinsSubBatchNo,HinsSubBatchSeq,HinsDiscountTerms,HinsInvoiceAmt,HinsAmtPaid,HinsNonMerchAmt,HinsInvoiceDate,HinsDateReceived,HinsDateKeyedIp,HinsInitialsIp,HinsDateKeyedPv,HinsInitialsPv,HinsRecDateReceived,HinsFundCode,HinsInvoiceStatus,HinsFederalInd,HinsNetDays,HinsAdjustInd,HinsActionCode,HinsInterestCode,HinsInterestAmt,HinsDiscountELCode,HinsDiscountELAmt,HinsAdminDiffAmt,HinsScheduleDate,HinsDocumentNo,HinsTreasMonth,HinsFssPoNo,HinsInternetInd,HinsPegDocNo,HinsInitTimestamp,HinsSourceFile,HinsCycleNo,HinsDeleteDate,HinsId,HinsPoId")] ArchHinvoiceSummary archHinvoiceSummary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(archHinvoiceSummary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(archHinvoiceSummary);
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archHinvoiceSummary = await _context.ArchHinvoiceSummary.FindAsync(id);
            if (archHinvoiceSummary == null)
            {
                return NotFound();
            }
            return View(archHinvoiceSummary);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HinsInvoiceNo,HinsPoNo,HinsVendorNo,HinsScheduleNo,HinsScheduleCheckSeq,HinsCheckNo,HinsCheckDate,HinsBatchNo,HinsSubBatchNo,HinsSubBatchSeq,HinsDiscountTerms,HinsInvoiceAmt,HinsAmtPaid,HinsNonMerchAmt,HinsInvoiceDate,HinsDateReceived,HinsDateKeyedIp,HinsInitialsIp,HinsDateKeyedPv,HinsInitialsPv,HinsRecDateReceived,HinsFundCode,HinsInvoiceStatus,HinsFederalInd,HinsNetDays,HinsAdjustInd,HinsActionCode,HinsInterestCode,HinsInterestAmt,HinsDiscountELCode,HinsDiscountELAmt,HinsAdminDiffAmt,HinsScheduleDate,HinsDocumentNo,HinsTreasMonth,HinsFssPoNo,HinsInternetInd,HinsPegDocNo,HinsInitTimestamp,HinsSourceFile,HinsCycleNo,HinsDeleteDate,HinsId,HinsPoId")] ArchHinvoiceSummary archHinvoiceSummary)
        {
            if (id != archHinvoiceSummary.HinsPoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(archHinvoiceSummary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArchHinvoiceSummaryExists(archHinvoiceSummary.HinsPoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(archHinvoiceSummary);
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var archHinvoiceSummary = await _context.ArchHinvoiceSummary
                .FirstOrDefaultAsync(m => m.HinsPoId == id);
            if (archHinvoiceSummary == null)
            {
                return NotFound();
            }

            return View(archHinvoiceSummary);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var archHinvoiceSummary = await _context.ArchHinvoiceSummary.FindAsync(id);
            _context.ArchHinvoiceSummary.Remove(archHinvoiceSummary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArchHinvoiceSummaryExists(string id)
        {
            return _context.ArchHinvoiceSummary.Any(e => e.HinsPoId == id);
        }
    }
}
