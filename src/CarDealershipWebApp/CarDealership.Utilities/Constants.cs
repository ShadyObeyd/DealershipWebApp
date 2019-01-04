﻿namespace CarDealership.Utilities
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
    }
}