namespace FCSeafood.BLL.User.Auth.Models.Response;

public record SignUpResponse(bool IsSuccessful, string Message) : IResponse;