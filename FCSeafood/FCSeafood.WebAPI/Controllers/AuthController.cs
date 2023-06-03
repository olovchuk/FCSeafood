using FCSeafood.BLL.User.Auth.Helpers;
using FCSeafood.BLL.User.Auth.Models.Params;
using Microsoft.AspNetCore.Authorization;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly JwtAuthCookieService _jwtCookieAuthService;

    public AuthController(JwtAuthCookieService jwtCookieAuthService) {
        _jwtCookieAuthService = jwtCookieAuthService;
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignInAsync(SignInParams singInParams) {
        var result = await _jwtCookieAuthService.SignInAsync(singInParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("SignInRefresh")]
    public async Task<IActionResult> SignInRefreshAsync(SignInRefreshParams signInRefreshParams) {
        var result = await _jwtCookieAuthService.SignInRefreshAsync(signInRefreshParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUpAsync(SignUpParams signUpParams) {
        var result = await _jwtCookieAuthService.SignUpAsync(signUpParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("SignOut"), Authorize]
    public IActionResult _SignOut() {
        var claims = JwtClaimsHelper.GetUserClaims(Request.HttpContext.User.Claims);
        var result = _jwtCookieAuthService.SignOut(new SignOutParams(claims.UserId));
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }
}