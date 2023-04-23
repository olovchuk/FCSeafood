namespace FCSeafood.BLL.User.Auth.Models.Response;

public record RefreshUserResponse(bool IsSuccessful, string Message, RoleType RoleType, Common.JWTAuthModel? JWTAuthModel) : IResponse;