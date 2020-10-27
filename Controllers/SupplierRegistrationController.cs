using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WrokFlowWeb.ViewModel.SupplierRegistration;
using static WrokFlowWeb.Constants.Constants;

namespace WrokFlowWeb.Controllers
{
    public class SupplierRegistrationController : Controller
    {
        public IActionResult Index()
        {
            SupplierRegistration model = new SupplierRegistration
            {
                Questions = new List<QuestionModel>()
            {
                new QuestionModel()
                {
                    QuestionText = "Have you worked with us before",
                    QuestionControlType = Controls.Textbox,
                    QuestionComment = "Comment 1",
                    QuestionAnswer="1"
                },
                new QuestionModel()
                {
                    QuestionText = "Please provide your details",
                     QuestionControlType = Controls.Textbox,
                    QuestionComment = "Comment 2",
                     QuestionAnswer="10"
                },
                 new QuestionModel()
                {
                    QuestionText = "Have you worked with us before on which time",
                     QuestionControlType = Controls.MultiLineTextox,
                    QuestionComment = "Comment 2",
                     QuestionAnswer="10"
                }, new QuestionModel()
                {
                    QuestionText = "Please select the country",
                    QuestionControlType = Controls.Dropdown,
                    QuestionComment = "Comment 2",
                    QuestionAnswer="10",
                    SelectedValue = 1001,
                    DataSource = new List<DropdownSource>()
                    {
                        new DropdownSource()
                        {
                            Id = 0,
                            Text = ""
                        },
                        new DropdownSource()
                        {
                            Id = 1000,
                            Text = "India"
                        },
                         new DropdownSource()
                        {
                            Id = 1001,
                            Text = "USA"
                        },
                          new DropdownSource()
                        {
                            Id = 1002,
                            Text = "Canada"
                        }
                    }
                },
                  new QuestionModel()
                {
                    QuestionText = "Please explain your proficency",
                    QuestionControlType = Controls.Textbox,
                    QuestionComment = "Comment 1",
                    QuestionAnswer=""
                },
            }
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SupplierRegistration supplierRegistration)
        {

            return View();
        }
    }
}
