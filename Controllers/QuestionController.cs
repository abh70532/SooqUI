using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.ViewModel.Question;

namespace WrokFlowWeb.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ISupplierRegistrationService supplierRegistrationService;

        public QuestionController(ISupplierRegistrationService supplierRegistrationService)
        {
            this.supplierRegistrationService = supplierRegistrationService;
        }

        public IActionResult Index()
        {
            var model = this.supplierRegistrationService.GetQuestionMasterViewModel();
            return View("CreateQuestion", model);
        }

        [HttpPost]
        public IActionResult Create(QuestionMasterViewModel questionMasterViewModel)
        {
            this.supplierRegistrationService.AddQuestionMaster(questionMasterViewModel);
            var responseModel =  this.supplierRegistrationService.GetAllQuestions();
            return View("QuestionList", responseModel);
        }

        [HttpGet]
        public IActionResult List()
        {
            var responseModel = this.supplierRegistrationService.GetAllQuestions();
            return View("QuestionList", responseModel);
        }
    }
}
