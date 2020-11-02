using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.ViewModel.SupplierRegistration;
using static WrokFlowWeb.Constants.Constants;

namespace WrokFlowWeb.Controllers
{
    public class SupplierRegistrationController : Controller
    {

        private readonly ISupplierRegistrationService supplierRegistrationService;

        public SupplierRegistrationController(ISupplierRegistrationService supplierRegistrationService)
        {
            this.supplierRegistrationService = supplierRegistrationService;
        }
        public IActionResult Index()
        {
            var model = this.supplierRegistrationService.GetAllQuestionByModule(1);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SupplierRegistration supplierRegistration)
        {

            return View();
        }

        public IActionResult GetInternalQuestionaire()
        {
            SupplierRegistrationInternalQuestionViewModel model = new SupplierRegistrationInternalQuestionViewModel();
            return View("InternalQuestionare", model);
        }
        public IActionResult SyncSAP()
        {
            SyncSAPViewModel model = new SyncSAPViewModel();
            return View("SyncSAP", model);
        }
    }
}
