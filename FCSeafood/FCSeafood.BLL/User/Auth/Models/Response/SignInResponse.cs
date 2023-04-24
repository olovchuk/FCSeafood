namespace FCSeafood.BLL.User.Auth.Models.Response;

public record SignInResponse(bool IsSuccessful, string Message, RoleType RoleType, JwtAuthModel? JwtAuthModel) : IResponse;