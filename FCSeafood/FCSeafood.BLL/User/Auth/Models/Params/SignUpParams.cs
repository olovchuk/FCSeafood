namespace FCSeafood.BLL.User.Auth.Models.Params;

public record SignUpParams(
    string Email
  , string Password
  , string FirstName
  , string LastName
);