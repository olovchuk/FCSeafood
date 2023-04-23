namespace FCSeafood.BLL.User.Info.Models.Response;

public record GetUserInformationResponse(bool IsSuccessful, string Message, UserInformationModel? UserInformationModel) : IResponse;