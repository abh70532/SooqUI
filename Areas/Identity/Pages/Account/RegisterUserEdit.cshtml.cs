using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WrokFlowWeb.Areas.Identity.Data;
using WrokFlowWeb.Database;
using WrokFlowWeb.Services.Interface;
using WrokFlowWeb.ViewModel.SupplierRequest;

namespace WrokFlowWeb.Areas.Identity.Pages.Account
{
    [Authorize]
    public class RegisterUserEditModel : PageModel
    {
        private readonly SignInManager<WrokFlowWebUser> _signInManager;
        private readonly UserManager<WrokFlowWebUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ISupplierRequestService _supplierRequestService;

        public RegisterUserEditModel(
            UserManager<WrokFlowWebUser> userManager,
            SignInManager<WrokFlowWebUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, ISupplierRequestService supplierRequestService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _supplierRequestService = supplierRequestService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public List<SuppilerListViewModel> SupplierRequests { get; set; }

        public class InputModel
        {
            public string Id { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
           
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

           

            [DataType(DataType.Date)]
            [Display(Name = "Start Date")]
            public string StartDate { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Department")]
            public string Department { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Internal/External User")]
            public byte UserType { get; set; }

            [Display(Name = "Supplier")]
            public long? SupplierRequestId { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Company Name")]
            public string CompanyName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Cost Center")]
            public string CostCenter { get; set; }
        }

        public async Task OnGetAsync(string id)
        {
            var response = await _supplierRequestService.GetUserListById(id);
            //InputModel input = new InputModel();
            Input = new InputModel() {
                Id = response.Id,
                CompanyName = response.CompanyName,
            CostCenter = response.CostCenter,
            Department = response.Department,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.LastName,

            
            SupplierRequestId = response.SupplierRequestId,
            UserType = response.UserType.GetValueOrDefault()
             };

            if (response.StartDate.HasValue)
            {
                Input.StartDate = response.StartDate.Value.ToString("dd-MM-yyyy");
            }
            
           
            var suppliers = _supplierRequestService.GetSupplierRequestMaster().Result;
            List<SuppilerListViewModel> suppilerListViewModels = new List<SuppilerListViewModel>();
            suppliers.ForEach(item => {
                suppilerListViewModels.Add(new SuppilerListViewModel()
                {
                    SupplierRequestId = item.SupplierRequestId,
                    SupplierName = string.Join('-', item.SupplierName, item.SupplierRequestId)
                });
            });

            SupplierRequests = suppilerListViewModels;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (Input.SupplierRequestId == null)
            {
              
                ModelState.ClearValidationState("Input.SupplierRequestId");
                ModelState.ClearValidationState("Input.CompanyName");
            }

            var response = await _supplierRequestService.GetUserListById(Input.Id);
                    response.FirstName = Input.FirstName;
                    response.LastName = Input.LastName;
                    response.Department = Input.Department;
                    response.UserType = Input.UserType;
                    response.SupplierRequestId = Input.SupplierRequestId;
                    response.CompanyName = Input.CompanyName;
                    response.CostCenter = Input.CostCenter;
                  if(await _supplierRequestService.UpdateUser(response)>0)
                    {
                        _logger.LogInformation("User registration  a new account with password.");
                        return RedirectToAction("ListUsers", "Role");
                    }
                  
                var suppliers = _supplierRequestService.GetSupplierRequestMaster().Result;
                List<SuppilerListViewModel> suppilerListViewModels = new List<SuppilerListViewModel>();
                suppliers.ForEach(item => {
                    suppilerListViewModels.Add(new SuppilerListViewModel()
                    {
                        SupplierRequestId = item.SupplierRequestId,
                        SupplierName = string.Join('-', item.SupplierName, item.SupplierRequestId)
                    });
                });

            SupplierRequests = suppilerListViewModels;

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
