

namespace FCSeafood.BLL.User.Info.Models.Response;

public record GetUserResponse(bool IsSuccessful, string Message, UserModel? UserModel) : IResponse;