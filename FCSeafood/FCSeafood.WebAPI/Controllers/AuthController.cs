using FCSeafood.BLL.User.Auth.Helpers;
using FCSeafood.BLL.User.Auth.Models.Params;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

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
        return Ok(await _jwtCookieAuthService.SignInAsync(singInParams));
    }

    [HttpPost("SignInGuest")]
    public async Task<IActionResult> SignInGuestAsync() {
        return Ok(await _jwtCookieAuthService.SignInGuestAsync());
    }

    [HttpPost("SignInRefresh")]
    public async Task<IActionResult> SignInRefreshAsync(SignInRefreshParams signInRefreshParams) {
        return Ok(await _jwtCookieAuthService.SignInRefreshAsync(signInRefreshParams));
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUpAsync(SignUpParams signUpParams) {
        return Ok(await _jwtCookieAuthService.SignUpAsync(signUpParams));
    }

    [HttpPost("SignOut"), Authorize]
    public IActionResult _SignOut() {
        var claims = JwtClaimsHelper.GetUserClaims(Request.HttpContext.User.Claims);
        return Ok(_jwtCookieAuthService.SignOut(new SignOutParams(claims.UserId)));
    }

    [HttpPost("ResetPassword"), Authorize]
    public async Task<IActionResult> ResetPasswordAsync() {
        var claims = JwtClaimsHelper.GetUserClaims(Request.HttpContext.User.Claims);
        return Ok(await _jwtCookieAuthService.ResetPasswordAsync(claims.UserId));
    }

    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordParams forgotPasswordParams) {
        return Ok(await _jwtCookieAuthService.ForgotPasswordAsync(forgotPasswordParams));
    }
}