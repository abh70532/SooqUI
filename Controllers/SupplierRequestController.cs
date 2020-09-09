using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WrokFlowWeb.Database;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.ViewModel;
using WrokFlowWeb.ViewModel.SupplierRequest;

namespace WrokFlowWeb.Controllers
{

    [Authorize]
    public class SupplierRequestController : Controller
    {
        private readonly ISupplierRequestService supplierRequest;

        public SupplierRequestController(ISupplierRequestService supplierRequest)
        {
            this.supplierRequest = supplierRequest;
        }
        public async Task<IActionResult> Index()
        {
           var result = await this.supplierRequest.GetSupplierRequests();
            return View();
        }

        public async Task<IActionResult> Get()
        {
            var model = new SupplierViewModel
            {
                SuplierTypeRequest = await this.supplierRequest.GetSupplierTypeRequestMaster(),
                RequestTypeMaster = await this.supplierRequest.GetRequestTypeMaster()
            };


            return View("Create", model);
        }

        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {       
            var result =  await this.supplierRequest.Add(supplierViewModel);
            var model = new SupplierRequestListViewModel()
            {
             SupplierRequestId = result,
              SupplierRequests = await supplierRequest.GetSupplierRequests()
            };
            return View("List", model);
        }

        public async Task<IActionResult> List()
        {
            var model = new SupplierRequestListViewModel()
            {
                SupplierRequests = await supplierRequest.GetSupplierRequests()
            };
            return View("List", model);
        }
    }
}
