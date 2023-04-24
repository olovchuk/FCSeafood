using FCSeafood.BLL.Common;
using FCSeafood.BLL.Common.Models.Params;
using FCSeafood.BLL.User.Info.Models.Params;

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

    [HttpGet("GetSubCategoryTList")]
    public async Task<IActionResult> GetSubCategoryTListAsync() {
        var result = await _commonManager.GetSubCategoryTListAsync();
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetSubCategoryByCategoryTList")]
    public async Task<IActionResult> GetSubCategoryTListAsync(CategoryTParams subCategoryTParams) {
        var result = await _commonManager.GetSubCategoryTListAsync(subCategoryTParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}