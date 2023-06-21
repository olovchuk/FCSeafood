namespace FCSeafood.BLL.User.Auth.Models.Response;

public record SignOutResponse(bool IsSuccessful, string Message) : IResponse;