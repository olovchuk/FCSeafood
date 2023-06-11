namespace FCSeafood.BusinessObjects.Error;

public static class ErrorMessage {
    public static class Repository {
        public static string Global => "An error was caught while manipulating the database;";
    }

    public static class Service {
        public static string Global => "An error occurred during a service operation;";
    }

    public static class Manager {
        public static string Global => "An error occurred during management;";
    }

    public static class User {
        public static string IsNotDefined => "The user is not defined.";
    }

    public static class Item {
        public static string IsNotDefined => "The item(s) is not defined.";
    }

    public static class Order {
        public static string IsNotDefined => "The order(s) is not defined.";
        public static string EntityInsertError => "Something went wrong while insert data.";
    }

    public static class Common {
        public static string ErrorRetrievingData => "Something goes wrong when retrieving data";
    }

    public static class Authentication {
        public static string AuthenticationFailed => "Authentication failed. Please please try to sign in again or contact us via freshcatch@gmail.com.";
        public static string AuthenticationGuestFailed => "Something went wrong with initialization Guest. Please please contact us via freshcatch@gmail.com.";
        public static string SignUpFailed => "Authentication failed. Please please try to sign in again or contact us via freshcatch@gmail.com.";
        public static string EmailOrPasswordIncorrect => "Email or Password incorrect. Please try again.";
        public static string EmailIsNotValidate => "Email is incorrect. Please try again.";
        public static string PasswordIsNotValidate => "Password should have at least 8 characters.";
        public static string FirstNameIsNotValidate => "First Name should have at least 2 characters.";
        public static string LastNameIsNotValidate => "Last Name should have at least 2 characters.";
        public static string InsertAddressFailed => "Something went wrong while adding address.";
        public static string InsertUserFailed => "Something went wrong while adding user.";
        public static string InsertCredentialFailed => "Something went wrong while adding credential.";
    }

    public static class Cookie {
        public static string Global => "An error occurred while manipulating cookies;";
    }

    public static class Jwt {
        public static string ValidateFailed => "An error occurred during validation;";
    }
}