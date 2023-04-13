namespace FCSeafood.BLL.User.Auth.Models.Params; 

public record RefreshUserParams(DAL.Events.Models.User User, string Email);