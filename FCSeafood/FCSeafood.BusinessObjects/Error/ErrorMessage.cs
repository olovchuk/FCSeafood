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

    public static class Authentication {
        public static string AuthenticationFailed => "Authentication failed. Please please try to sign in again or contact us via freshcatch@gmail.com.";
        public static string EmailOrPasswordIncorrect => "Email or Password incorrect. Please try again.";
    }
}