using System.Security.Claims;

namespace FCSeafood.BLL.User.Auth.Helpers;

public abstract class JwtClaimsHelper {
    public static UserClaimsModel GetUserClaims(IEnumerable<Claim> claims) {
        var result = new UserClaimsModel();

        var enumerable = claims as Claim[] ?? claims.ToArray();
        var userIdString = enumerable
                          .FirstOrDefault(
                               x => x.Type.Equals(JwtCustomClaims.UserId, StringComparison.OrdinalIgnoreCase)
                           )
                         ?.Value;
        if (Guid.TryParse(userIdString, out var userId))
            result.UserId = userId;

        var userEmail = enumerable
                       .FirstOrDefault(x => x.Type.Equals(JwtCustomClaims.Email, StringComparison.OrdinalIgnoreCase))
                      ?.Value;
        result.Email = userEmail ?? "";

        var userRoleString = enumerable
                            .FirstOrDefault(
                                 x => x.Type.Equals(JwtCustomClaims.RoleType, StringComparison.OrdinalIgnoreCase)
                             )
                           ?.Value;
        if (int.TryParse(userRoleString, out var userRole))
            result.RoleType = (RoleType)userRole;

        return result;
    }
}