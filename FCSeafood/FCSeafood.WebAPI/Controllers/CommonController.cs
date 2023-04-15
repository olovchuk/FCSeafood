using FCSeafood.BLL.Common;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommonController : ControllerBase {
    private readonly CommonManager _commonManager;

    public CommonController(CommonManager commonManager) {
        _commonManager = commonManager;
    }

    [HttpGet("GetCategoryTypeList")]
    public async Task<IActionResult> GetCategoryTypeListAsync() {
        var result = await _commonManager.GetCategoryTypeListAsync();
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}