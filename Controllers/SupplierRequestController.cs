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
using static WrokFlowWeb.Constants.Constants;

namespace WrokFlowWeb.Controllers
{

    [Authorize]
    public class SupplierRequestController : Controller
    {
        private readonly ISupplierRequestService supplierRequest;
        private readonly ICategoryMasterService categoryService;

        public SupplierRequestController(ISupplierRequestService supplierRequest,ICategoryMasterService categoryMasterService)
        {
            this.supplierRequest = supplierRequest;
            this.categoryService = categoryMasterService;
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
            var model = await bindSupplierViewModel(response);
            var ids = response.SupplierRequestCategoryMapping.Select(x => x.CategoryMasterId).ToList();
            model.CategoryMaster.Where(c => ids.Contains(c.CategoryMasterId)).ToList().ForEach(option=> {
                option.IsSelected = true;
            });

            return View("Edit", model);
        }


        async Task<SupplierViewModel> bindSupplierViewModel(SupplierRequest response)
        {
            
            var model = new SupplierViewModel()
            {
                SupplierRequestId = response.SupplierRequestId,
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
            return model;
        }

        [HttpGet]
        public async Task<IActionResult> InboxList()
        {
          List<InboxListViewModel> model  = this.supplierRequest.GetInboxList(this.User.Identity.Name);
          return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Approve(long requestid, long moduleid)
        {
            RequestApprovalViewModel model = new RequestApprovalViewModel
            {
                InboxListViewModel = new InboxListViewModel()
                {
                    RequestId = requestid,
                    ModuleId = moduleid
                }
            };
            switch (moduleid)
            {
                case (long)Module.SupplierRequest:
                    var response = await this.supplierRequest.GetSupplierRequest(requestid);
                     model.SupplierViewModel = await bindSupplierViewModel(response);
                     model.SupplierRequestApprovalLog = await this.supplierRequest.GetApprovedLogBySupplierRequestId(requestid);
                    return View("SupplierApproveView", model);
                default:
                    break;
            }

            return null;
        }

        [HttpGet]
        public async Task<IActionResult> ViewApprovals(long requestid, long moduleid)
        {
            RequestApprovalViewModel model = new RequestApprovalViewModel
            {
                IsView = true,
                InboxListViewModel = new InboxListViewModel()
                {
                    RequestId = requestid,
                    ModuleId = moduleid
                }
            };
            switch (moduleid)
            {
                case (long)Module.SupplierRequest:
                    var response = await this.supplierRequest.GetSupplierRequest(requestid);
                    model.SupplierViewModel = await bindSupplierViewModel(response);
                    model.SupplierRequestApprovalLog = await this.supplierRequest.GetApprovedLogBySupplierRequestId(requestid);
                    return View("SupplierApproveView", model);
                default:
                    break;
            }

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Approve(RequestApprovalViewModel requestApprovalViewModel)
        {
            await this.supplierRequest.ApproveUpdate(requestApprovalViewModel, this.User.Identity.Name);

           return RedirectToAction("InboxList");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList(string search)
        {
            var model = await this.categoryService.GetAllCategories();
            model = !string.IsNullOrEmpty(search) ? model.Where(x=>x.Category.ToLower().Contains(search.ToLower()) ||  x.Description.ToLower().Contains(search.ToLower())).ToList(): model;
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_CategoryList", model);

            return View("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryEdit(int categoryMasterid)
        {
            return RedirectToAction("CategoryEdit", "master", new { categoryId = categoryMasterid });
        }
    }
}  