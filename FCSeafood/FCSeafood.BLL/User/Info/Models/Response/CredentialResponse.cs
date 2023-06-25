namespace FCSeafood.BLL.User.Info.Models.Response;

public record CredentialResponse(
    bool IsSuccessful
  , string Message
  , UserCredentialModel? UserCredentialModel
) : IResponse;