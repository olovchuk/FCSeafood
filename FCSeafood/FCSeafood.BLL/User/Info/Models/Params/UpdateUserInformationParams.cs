namespace FCSeafood.BLL.User.Info.Models.Params;

public record UpdateUserInformationParams(
    Guid UserId
  , string FirstName
  , string LastName
  , GenderType GenderType
  , string? Phone
  , DateTime? DateOfBirth
);