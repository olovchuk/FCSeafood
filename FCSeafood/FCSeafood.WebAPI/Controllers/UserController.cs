using FCSeafood.BLL.User.Info;
using FCSeafood.BLL.User.Info.Models.Params;
using Microsoft.AspNetCore.Mvc;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase {
    private readonly UserManager _userManager;

    public UserController(UserManager userManager) {
        _userManager = userManager;
    }

    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser([FromQuery]GetUserParams getUserParams) {
        var result = await _userManager.GetUser(getUserParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}