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

    [HttpGet("GetCategoryType")]
    public async Task<IActionResult> GetCategoryTAsync([FromQuery] CategoryTParams categoryTParams) {
        var result = await _commonManager.GetCategoryTypeAsync(categoryTParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetCategoryBySubcategoryType")]
    public async Task<IActionResult> GetCategoryTAsync([FromQuery] SubcategoryTParams subcategoryTParams) {
        var result = await _commonManager.GetCategoryTypeAsync(subcategoryTParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetCategoryTList")]
    public async Task<IActionResult> GetCategoryTListAsync() {
        var result = await _commonManager.GetCategoryTListAsync();
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetSubcategoryTList")]
    public async Task<IActionResult> GetSubcategoryTListAsync() {
        var result = await _commonManager.GetSubcategoryTListAsync();
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetSubcategoryByCategoryTList")]
    public async Task<IActionResult> GetSubcategoryTListAsync([FromQuery] CategoryTParams subcategoryTParams) {
        var result = await _commonManager.GetSubcategoryTListAsync(subcategoryTParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }
}