using FCSeafood.BusinessObjects;

namespace FCSeafood.BLL.User.Auth.Models.Response;

public record SignInResponse(bool IsSuccessful, string Message, RoleType RoleType, Common.JWTAuthModel? JWTAuthModel);