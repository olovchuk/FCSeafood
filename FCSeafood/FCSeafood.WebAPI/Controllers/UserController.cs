using FCSeafood.BLL.User.Auth.Helpers;
using FCSeafood.BLL.User.Info;
using FCSeafood.BLL.User.Info.Models.Params;
using Microsoft.AspNetCore.Authorization;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly UserManager _userManager;

    public UserController(UserManager userManager) {
        _userManager = userManager;
    }

    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUserAsync([FromQuery] UserIdParams userIdParams) {
        return Ok(await _userManager.GetUser(userIdParams));
    }

    [HttpGet("GetUserInformation"), Authorize]
    public async Task<IActionResult> GetUserInformation() {
        var claimsValues = JwtClaimsHelper.GetUserClaims(Request.HttpContext.User.Claims);
        return Ok(await _userManager.GetUserInformationAsync(new UserIdParams(claimsValues.UserId)));
    }

    [HttpPost("UpdateUserAddress")]
    public async Task<IActionResult> UpdateUserAddressAsync(UpdateUserAddressParams updateUserAddressParams) {
        await _userManager.UpdateUserAddressAsync(updateUserAddressParams);
        return Ok();
    }
}