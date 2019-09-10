using FedPayArchiver.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FedPayArchiver.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly FedPayArchiverContext _context;

        public PurchaseOrderController(FedPayArchiverContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Param()
        {

            //HttpContext.Session.SetString(SessionKeyPO, "");
            //HttpContext.Session.SetString(SessionKeyInv, "");

            return View();

        }
        public async Task<IActionResult> Index(ArchHpoSummary po, string pos, string faspo)
        {

            if (!String.IsNullOrEmpty(pos) || !String.IsNullOrEmpty(faspo))
            {
                po.HposPoNo = pos;
                po.HposFssPoNo = faspo;
            }

            //Below was used for testing an edit
            //if (po.ADD_PO_NO.Substring(0, 1) != "3")
            //{
            //    List<AdmDiffStmtVw> addDiff = await _context.AdmDiffStmtVw.Where(adiff => adiff.ADD_PO_NO == null).ToListAsync();
            //    ViewBag.SearchCriteria = po.ADD_PO_NO;
            //    ViewBag.SearchRes = "PO used in Search Criteria must begin with a 3. Please Click New Search and change PO# to a valid PO#";
            //    return View(addDiff);
            //}
            if (po.HposPoNo != null && po.HposFssPoNo is null)
            {
                //HttpContext.Session.SetString(SessionKeyPO, po.ADD_PO_NO);
                List<ArchHpoSummary> hPos   = await _context.ArchHpoSummary.Where(hPostab => hPostab.HposPoNo == po.HposPoNo).
                    OrderByDescending(hPostab => hPostab.HposDateOfOrder).ToListAsync();
                if (hPos.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested FEDPAY PO#";
                }
                else
                {
                    ViewBag.SearchRes = " ";
                }

                ViewBag.SearchCriteria = "FEDPAY PO#  " + po.HposPoNo;
                return View(hPos);
            }
            else if (po.HposPoNo is null && po.HposFssPoNo != null)
            {
                //HttpContext.Session.SetString(SessionKeyInv, po.ADD_INVOICE_NO);
                List<ArchHpoSummary> hPos = await _context.ArchHpoSummary.Where(hPostab => hPostab.HposFssPoNo == po.HposFssPoNo).
                    OrderByDescending(hPostab => hPostab.HposDateOfOrder).ToListAsync();
                if (hPos.Count == 0)
                {
                    ViewBag.SearchRes = "NO Results were Found for Requested FAS PO#";
                }
                else
                {
                    ViewBag.SearchRes = " ";

                }
                ViewBag.SearchCriteria = "FAS PO# " + po.HposFssPoNo;
                return View(hPos);
            }
            else
            {
                List<ArchHpoSummary> hPos = await _context.ArchHpoSummary.Where(hPostab => hPostab.HposPoNo == null).ToListAsync();
                ViewBag.SearchCriteria = "No Search Criteria was Entered";
                ViewBag.SearchRes = "Please Click New Search and enter one search criteria";
                return View(hPos);
            }


        }
        public async Task<IActionResult> POL (string poid,DateTime OrderDate,string SrchCriteria)
        {


                List<ArchHpoLineItem> hPol = await _context.ArchHpoLineItem.Where(hPoltab => hPoltab.HpolPoId == poid).
                    OrderByDescending(hPoltab => hPoltab.HpolSeqNo).ToListAsync();

            ViewBag.OrdDt = OrderDate;
            ViewBag.SearchCriteria = SrchCriteria;

            return View(hPol);
        }

        public async Task<IActionResult> POA(string poid, DateTime OrderDate)
        {
            //There are 2 possible areas to look first in the HPOA table and second place to pull information is from HINL (only pull from HINL if not in HPOA)
            // Selecting from area #1  HPOA
            List<ArchHpoLineItemActivity> hPoa = await _context.ArchHpoLineItemActivity.Where(hPoatab => hPoatab.HpoaPoId == poid).
                OrderBy(hPoatab => hPoatab.HpoaPolSeqNo).OrderBy(hPoatab => hPoatab.HpoaSeqNo).ToListAsync();

            if (hPoa.Count == 0)
            {
                // Look at area #2
                LineItemActivity lia = new LineItemActivity();
                lia.PoId = poid;
                lia.SrchCriteria = ViewBag.SearchCriteria;
                lia.OrdDate = OrderDate;
                ViewBag.an = "POA2";
                ViewBag.cn = "PurchaseOrderController";

                //return RedirectToAction(ViewBag.an, ViewBag.cn, lia); 
                return RedirectToAction(ViewBag.an, lia);
            }
            else
            { 
                ViewBag.OrdDt = OrderDate;

                return View(hPoa);
            }
        }

        public async Task<IActionResult> POA2(string poid, DateTime OrderDate, LineItemActivity lia)
        {
            //Selecting from area #2  HINL (only pull from HINL if not in HPOA)

            List<ArchHinvoiceLineItem> hInl = await _context.ArchHinvoiceLineItem.Where(hInltab => hInltab.HinlPoId == lia.PoId).
                OrderBy(hInltab => hInltab.HinlSeqNo).OrderBy(hInltab => hInltab.HinlPolSeqNo).ToListAsync();
            if (hInl.Count == 0)
            {
                ViewBag.SearchRes = "Please Click New Search and enter one search criteria";
            }

            ViewBag.OrdDt = OrderDate;

            return View(hInl);

        }


        public async Task<IActionResult> PON(string poid, DateTime OrderDate)
        {


            List<ArchHpoNote> hPon = await _context.ArchHpoNote.Where(hPontab => hPontab.HponPoId == poid).
                OrderBy(hPontab => hPontab.HponSeqNo).ToListAsync();

            ViewBag.OrdDt = OrderDate;

            return View(hPon);
        }
    }

    public class LineItemActivity
    {
        public string PoId { get; set; }
        public string SrchCriteria { get; set; }
        public DateTime OrdDate { get; set; }
    }
}
