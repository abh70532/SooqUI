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
    public class RegisterUserModel : PageModel
    {
        private readonly SignInManager<WrokFlowWebUser> _signInManager;
        private readonly UserManager<WrokFlowWebUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ISupplierRequestService _supplierRequestService;

        public RegisterUserModel(
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
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

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

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            
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
                var user = new WrokFlowWebUser { UserName = Input.Email, Email = Input.Email,FirstName=Input.FirstName,
                    LastName=Input.LastName,Department=Input.Department,StartDate= Convert.ToDateTime(Input.StartDate),
                    UserType = Input.UserType,SupplierRequestId = Input.SupplierRequestId,
                    CompanyName = Input.CompanyName,
                    CostCenter= Input.CostCenter
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User registration  a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        return RedirectToAction("ListUsers", "Role");
                    }
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
            foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
