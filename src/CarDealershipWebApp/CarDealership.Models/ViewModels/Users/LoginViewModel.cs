using CarDealership.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(Constants.UsernameMinLength, ErrorMessage = Constants.UsernameMinLengthMessage)]
        [RegularExpression(Constants.UsernameValidationRegex, ErrorMessage =Constants.UsernameRegexMessage)]
        public string Username { get; set; }

        [Required]
        [MinLength(Constants.PasswordMinLength, ErrorMessage = Constants.PasswordMinLengthMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}