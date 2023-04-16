using FCSeafood.BLL.User.Auth.Helpers;
using FCSeafood.BLL.User.Auth.Models.Params;
using Microsoft.AspNetCore.Authorization;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly JWTAuthCookieService _jwtCookieAuthService;

    public AuthController(JWTAuthCookieService jwtCookieAuthService) {
        _jwtCookieAuthService = jwtCookieAuthService;
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignInAsync(SignInParams singInParams) {
        var result = await _jwtCookieAuthService.SignInAsync(singInParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("SignInRefresh")]
    public async Task<IActionResult> SignInRefreshAsync(SignInRefreshParams SignInRefreshParams) {
        var result = await _jwtCookieAuthService.SignInRefreshAsync(SignInRefreshParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("SignOut")]
    public IActionResult _SignOut() {
        var claims = JWTClaimsHelper.GetUserClaims(Request.HttpContext.User.Claims);
        var result = _jwtCookieAuthService.SignOut(new SignOutParams(claims.UserId));
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}