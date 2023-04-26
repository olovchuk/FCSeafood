namespace FCSeafood.BusinessObjects.Error;

public static class ErrorMessage {
    public static class Repository {
        public static string Global => "An error was caught while manipulating the database;";
    }

    public static class Service {
        public static string Global => "An error occurred during a service operation;";
    }
}