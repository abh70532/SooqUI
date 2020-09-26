using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.ViewModel.CategoryMaster;

namespace WrokFlowWeb.Controllers
{
    [Authorize]
    public class MasterController : Controller
    {
        public IMasterService MasterService { get; }

        public MasterController(IMasterService masterService)
        {
            MasterService = masterService;
        }
        
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public IActionResult CategoryCreate()
        {
            CategoryMasterViewModel categoryMasterViewModel = new CategoryMasterViewModel();
            return View("CategoryCreate", categoryMasterViewModel);
        }

        public async Task<IActionResult> CreateCategory(CategoryMasterViewModel categoryMasterViewModel)
        {

            if (ModelState.IsValid)
            {
                if (await MasterService.AddCategory(categoryMasterViewModel) > 0)
                {
                    return RedirectToAction("CategoryList", "SupplierRequest");
                }
            }
            return View();
        }

        public async Task<IActionResult> CategoryEdit(int categoryId)
        {
            var response = await MasterService.GetCategoryById(categoryId);
            CategoryMasterViewModel categoryMasterViewModel = new CategoryMasterViewModel() { 
                 Category = response.Category,
                 CategoryMasterId = response.CategoryMasterId,
                 Description = response.Description
            };
            return View("CategoryEdit", categoryMasterViewModel);
        }

        public async Task<IActionResult> CategoryEditUpdate(CategoryMasterViewModel categoryMasterViewModel)
        {
            if (ModelState.IsValid)
            {
                await MasterService.UpdateCategory(categoryMasterViewModel);
               
            }
            return RedirectToAction("CategoryList", "SupplierRequest");
        }
    }
}
