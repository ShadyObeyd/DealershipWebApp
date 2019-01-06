using System;

namespace CarDealership.Utilities
{
    public class Constants
    {
        public const int UsernameMinLength = 4;
        public const string UsernameMinLengthMessage = "Username must contain at least 4 symbols";
        public const string UsernameValidationRegex = @"^[A-Za-z0-9-_\.*`@]+$";
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
        public const string ErrorView = "Error";

        public const string AllNewsView = "All";
        public const string NewsController = "News";

        public const string InvalidUserMessage = "The requested account does not exist or it has been deleted.";
        public const string InvalidNewsInputModelMessage = "News Title or Content must not be empty!";
        public const string NewsNotFoundMessage = "The requested news does not exist or it has been deleted.";

        public const string ReadNewsView = "Read";

        public const string CommentErrorMessage = "The comment you are trying to delete does not exist.";
        public const string CommentContentErrorMessage = "Cannot add an empty comment!";

        public const string CarType = "CarAdd";
        public const string TruckType = "TruckAdd";
        public const string MotorcycleType = "MotorcycleAdd";

        public const string CarHorsePowerErrorMessage = "Car horse power must be between 10 and 2000";
        public const string CarYearOfProductionErrorMessage = "Year of production must be between 1901 and 2019";

        public const string GasolineAndLpgEngineTypeInput = "Gasoline / LPG";
        public const string GasolineAndLpgEngineTypeCorrection = "GasolineAndLPG";

        public const string CarAddInputErrorMessage = "Car engine type, transmission or category is invalid!";

        public const string RootDirectory = "wwwroot";

        public const string PictureNotValidMessage = "One or more files is not a valid jpeg file!";

        public const string CarStringPropertyDefaultValue = "Any";
        public const int CarNumberPropertyDefaultValue = 0;

        public const string ViewAddsView = "ViewAdds";

        public const string PriceMinValue = "1";
        public const string PriceMaxValue = "79228162514264337593543950335";
        public const string PriceErrorMessage = "Price cannot be a negative value!";
        public const int YearMinValue = 1901;
        public const int YearMaxValue = 2019;

        public const string CarHorsePowerDisplayStr = "Horse Powers";

        public const string CarEngineTypeDisplayStr = "Engine Type";

        public const int CarMinHorsePower = 10;
        public const int CarMaxHorsePower = 2000;

        public const string ThreeDots = "...";

        public const string AddNotFoundMessage = "Add does not exist.";

        public const string ViewAddView = "ViewAdd";

        public const string MyAddsView = "MyAdds";
        public const string AddsController = "Adds";
    }
}