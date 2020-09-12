using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                RequestTypeMaster = await this.supplierRequest.GetRequestTypeMaster(),
                CategoryMaster = await this.supplierRequest.GetCategoryMaster(),
            };
            return View("Create", model);
        }

        public async Task<IActionResult> Create(SupplierViewModel supplierViewModel)
        {
            var user = this.User.Identity.Name;
            supplierViewModel.CreatedBy = user;
            var result =  await this.supplierRequest.Add(supplierViewModel);
            return RedirectToAction("List", new { requestid = result });
        }

        public async Task<IActionResult> List(long requestid)
        {

            var model = new SupplierRequestListViewModel()
            {
                SupplierRequestId = requestid,
                SupplierRequests = await supplierRequest.GetSupplierRequests()
            };
            return View("List", model);
        }


        [HttpGet]
        public  Task<IActionResult> Details(long requestid)
        {

            return Edit(requestid);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(long requestid)
        {
            var response = await this.supplierRequest.GetSupplierRequest(requestid);

                var model = new SupplierViewModel()
                {
                    SuplierTypeRequest = await this.supplierRequest.GetSupplierTypeRequestMaster(),
                    RequestTypeMaster = await this.supplierRequest.GetRequestTypeMaster(),
                    CategoryMaster = await this.supplierRequest.GetCategoryMaster(),
                    SuplierTypeRequestId = response.SuplierTypeRequestId,
                    RequestTypeMasterId = response.RequestTypeMasterId,
                    RequesterName = response.RequesterName,
                    Department = response.Department,
                    SupplierName = response.SupplierName,
                    Street = response.Street,
                    Address1 = response.Address1,
                    Address2 = response.Address2,
                    City = response.City,
                    PostalCode = response.PostalCode,
                    Country = response.Country,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    EmailId = response.EmailId,
                    ContactPhone = response.ContactPhone
                };
            var ids = response.SupplierRequestCategoryMapping.Select(x => x.CategoryMasterId).ToList();
            model.CategoryMaster.Where(c => ids.Contains(c.CategoryMasterId)).ToList().ForEach(option=> {
                option.IsSelected = true;
            });

            return View("Edit", model);
        }
    }
}
