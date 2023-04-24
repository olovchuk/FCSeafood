using FCSeafood.BLL.User.Auth.Helpers;
using FCSeafood.BLL.User.Info;
using FCSeafood.BLL.User.Info.Models.Params;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly UserManager _userManager;

    public UserController(UserManager userManager) {
        _userManager = userManager;
    }

    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUserAsync([FromQuery] GetUserParams getUserParams) {
        var result = await _userManager.GetUser(getUserParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetUserInformation")]
    public async Task<IActionResult> GetUserInformation() {
        var claimsValues = JwtClaimsHelper.GetUserClaims(Request.HttpContext.User.Claims);
        var result = await _userManager.GetUserInformationAsync(new GetUserInformationParams(claimsValues.UserId));
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}