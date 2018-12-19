using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using CarDealership.Models.DataModels;
using CarDealership.Utilities;

namespace CarDealership.App.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<DealershipUser> _signInManager;
        private readonly UserManager<DealershipUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<DealershipUser> userManager,
            SignInManager<DealershipUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            private const string FirstNameDisplayStr = "First Name";
            private const string MiddleNameDisplayStr = "Middle Name";
            private const string LastNameDisplayStr = "Last Name";
            private const string ConfirmPasswordDisplayStr = "Confirm Password";
            private const string ConfirmPasswordCompareProperty = "Password";

            [Required]
            [MinLength(Constants.UsernameMinLength, ErrorMessage = Constants.UsernameMinLengthMessage)]
            [RegularExpression(Constants.UsernameValidationRegex, ErrorMessage = Constants.UsernameRegexMessage)]
            public string Username { get; set; }

            [Required]
            [MinLength(Constants.PasswordMinLength, ErrorMessage = Constants.PasswordMinLengthMessage)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = ConfirmPasswordDisplayStr)]
            [Compare(ConfirmPasswordCompareProperty, ErrorMessage = Constants.PasswordDoNotMatchMessage)]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress(ErrorMessage = Constants.EmailErrorMessage)]
            public string Email { get; set; }

            [Display(Name = FirstNameDisplayStr)]
            [RegularExpression(Constants.NameValidationRegex)]
            public string FirstName { get; set; }

            [Display(Name = MiddleNameDisplayStr)]
            [RegularExpression(Constants.NameValidationRegex)]
            public string MiddleName { get; set; }

            [Display(Name = LastNameDisplayStr)]
            [RegularExpression(Constants.NameValidationRegex)]
            public string LastName { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new DealershipUser
                {
                    UserName = Input.Username,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    MiddleName = Input.MiddleName,
                    LastName = Input.LastName
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
