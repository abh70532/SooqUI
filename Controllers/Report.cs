using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.ViewModel;

namespace WrokFlowWeb.Controllers
{
    public class ReportController : Controller
    {
        private readonly ISupplierRequestService supplierRequest;
        public ReportController(ISupplierRequestService supplierRequest)
        {
            this.supplierRequest = supplierRequest;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SupplierReport()
        {
            SupplierReportViewModel  supplierReportViewModel = new SupplierReportViewModel();
            return View("SupplierReportList", supplierReportViewModel);
        }

        [HttpPost]
        public IActionResult FetchSupplierReport(SupplierReportViewModel supplierReportViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("FetchSupplierReportData", supplierReportViewModel);
            }
            return View("SupplierReportList", supplierReportViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FetchSupplierReportData(SupplierReportViewModel supplierReportViewModel)
        {
            supplierReportViewModel.SupplierRequests = await this.supplierRequest.FetchSupplierReport(supplierReportViewModel);
            return View("SupplierReportList", supplierReportViewModel);
        }
    }
}

