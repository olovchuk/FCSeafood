using System.Security.Claims;
using FCSeafood.BLL.User.Auth.Helpers.Models.Claims;
using FCSeafood.DAL.Events;

namespace FCSeafood.BLL.User.Auth.Helpers;

public class JWTClaimsHelper {
    public static UserClaimsModel GetUserClaims(IEnumerable<Claim> claims) {
        var result = new UserClaimsModel();

        var userIdString = claims?.FirstOrDefault(x => x.Type.Equals(JWTCustomClaims.UserId, StringComparison.OrdinalIgnoreCase))?.Value;
        if (Guid.TryParse(userIdString, out var userId)) result.UserId = userId;

        var userEmail = claims?.FirstOrDefault(x => x.Type.Equals(JWTCustomClaims.Email, StringComparison.OrdinalIgnoreCase))?.Value;
        result.Email = userEmail ?? "";

        var userRoleString = claims?.FirstOrDefault(x => x.Type.Equals(JWTCustomClaims.RoleType, StringComparison.OrdinalIgnoreCase))?.Value;
        if (int.TryParse(userRoleString, out var userRole)) result.RoleType = (RoleType)userRole;

        return result;
    }
}