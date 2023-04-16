using FCSeafood.BusinessObjects;

namespace FCSeafood.BLL.User.Auth.Helpers.Models.Claims;

public class UserClaimsModel {
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public RoleType RoleType { get; set; }

    public bool IsValid => UserId != Guid.Empty && !string.IsNullOrWhiteSpace(Email);
}