using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FCSeafood.BLL.User.Auth.Helpers.Models;

public static class TokenGenerator {
    public static string GenerateJwtToken(
        string secretKey
      , string issuer
      , string audience
      , int expiresInSeconds
      , IEnumerable<Claim>? claims = null
    ) {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: issuer
          , audience: audience
          , claims: claims
          , expires: DateTime.Now.AddSeconds(expiresInSeconds)
          , signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}