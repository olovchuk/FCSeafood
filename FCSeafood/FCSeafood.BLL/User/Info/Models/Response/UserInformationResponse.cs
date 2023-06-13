namespace FCSeafood.BLL.User.Info.Models.Response;

public record UserInformationResponse(
    bool IsSuccessful
  , string Message
  , UserInformationModel? UserInformationModel
) : IResponse;