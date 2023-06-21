namespace FCSeafood.BLL.User.Auth.Models.Response;

public record RefreshGuestResponse(
    bool IsSuccessful
  , string Message
  , RoleType RoleType
  , JwtAuthModel? JwtAuthModel
) : IResponse;