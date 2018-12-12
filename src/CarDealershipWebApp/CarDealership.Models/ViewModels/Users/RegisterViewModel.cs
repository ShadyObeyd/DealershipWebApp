using CarDealership.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Users
{
    public class RegisterViewModel
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
}
