namespace FCSeafood.BLL.User.Info.Models.Response;

public record UserResponse(
    bool IsSuccessful
  , string Message
  , UserModel? UserModel
) : IResponse;