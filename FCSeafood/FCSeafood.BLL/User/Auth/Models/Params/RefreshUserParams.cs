using FCSeafood.BusinessObjects.Models.Events;

namespace FCSeafood.BLL.User.Auth.Models.Params;

public record RefreshUserParams(UserModel User, string Email);