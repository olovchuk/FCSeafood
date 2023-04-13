using FCSeafood.BLL.User.Auth.Models.Params;
using Microsoft.AspNetCore.Mvc;

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
}