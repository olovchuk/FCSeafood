namespace FCSeafood.BLL.User.Auth.Models.Response;

public record SignInResponse(bool IsSuccessful, string Message, DAL.Events.RoleType RoleType, Common.JWTAuthModel? JWTAuthModel);