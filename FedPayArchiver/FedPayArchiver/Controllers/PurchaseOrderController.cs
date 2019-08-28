using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;
using FedPayArchiver.Models;
using FedPayArchiver.EFModels;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FedPayArchiver.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly fedpayArhiverContext _context;

        public PurchaseOrderController(fedpayArhiverContext context)
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
    }
}
