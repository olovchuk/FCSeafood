using FCSeafood.BLL.Common;
using FCSeafood.BLL.Common.Models.Params;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommonController : ControllerBase {
    private readonly CommonManager _commonManager;

    public CommonController(CommonManager commonManager) {
        _commonManager = commonManager;
    }

    [HttpGet("GetCategoryTList")]
    public async Task<IActionResult> GetCategoryTListAsync() {
        var result = await _commonManager.GetCategoryTListAsync();
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetSubcategoryTList")]
    public async Task<IActionResult> GetSubcategoryTListAsync() {
        var result = await _commonManager.GetSubcategoryTListAsync();
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetSubcategoryByCategoryTList")]
    public async Task<IActionResult> GetSubcategoryTListAsync([FromQuery] CategoryTParams subcategoryTParams) {
        var result = await _commonManager.GetSubcategoryTListAsync(subcategoryTParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetBindCategoryList")]
    public async Task<IActionResult> GetBindCategoryListAsync() {
        var result = await _commonManager.GetBindCategoryListAsync();
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}