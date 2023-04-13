using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using FCSeafood.DAL.Events;

namespace FCSeafood.BLL.User.Auth.Helpers;

public abstract class BaseJWTHelper {
    private readonly IJWTSettings _jwtSettings;

    public BaseJWTHelper(IJWTSettings jwtSettings) {
        _jwtSettings = jwtSettings;
    }

    public string GenerateJWT(Guid userId, string userEmail, RoleType userRoleType) {
        var claims = new List<Claim> {
            new(JWTCustomClaims.UserId, userId.ToString())
          , new(JWTCustomClaims.Email, userEmail)
          , new(JWTCustomClaims.RoleType, ((int)userRoleType).ToString())
        };

        return TokenGenerator.GenerateJwtToken(_jwtSettings.Secret, _jwtSettings.Issuer, _jwtSettings.Audience, _jwtSettings.TokenLifeTime, claims);
    }

    public JwtSecurityToken? Validate(string tokenValue) {
        var tokenValidationParameters = new TokenValidationParameters {
            ValidateIssuer = true
          , ValidIssuer = _jwtSettings.Issuer
          , ValidateAudience = true
          , ValidAudience = _jwtSettings.Audience
          , ValidateLifetime = true
          , IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
          , ValidateIssuerSigningKey = true
        };
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        try {
            jwtSecurityTokenHandler.ValidateToken(tokenValue, tokenValidationParameters, out var validatedToken);
            return jwtSecurityTokenHandler.ReadJwtToken(tokenValue);
        } catch (Exception ex) { return null; }
    }
}