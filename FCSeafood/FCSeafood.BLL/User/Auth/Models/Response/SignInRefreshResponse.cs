namespace FCSeafood.BLL.User.Auth.Models.Response;

public record SignInRefreshResponse(bool IsSuccessful, string Message, JwtAuthModel? JwtAuthModel) : IResponse;