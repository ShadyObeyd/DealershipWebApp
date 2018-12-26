namespace CarDealership.Utilities
{
    public class Constants
    {
        public const int UsernameMinLength = 4;
        public const string UsernameMinLengthMessage = "Username must contain at least 4 symbols";
        public const string UsernameValidationRegex = @"^[A-Za-z0-9-_\.*`]+$";
        public const string UsernameRegexMessage = "Username may contain only alphanumeric characters, dashes, underscores, dots, asterisks and tildes";

        public const int PasswordMinLength = 5;
        public const string PasswordMinLengthMessage = "Password must be at least 5 symbols long";
        public const string PasswordDoNotMatchMessage = "Password and Confirm Password do not match";

        public const string NameValidationRegex = @"^[A-Za-z]+$";

        public const string EmailErrorMessage = "The entered email is not valid";

        public const string AdminRole = "Admin";
        public const string UserRole = "User";

        public const string AdministrationArea = "Administration";

        public const string IndexView = "Index";
    }
}
