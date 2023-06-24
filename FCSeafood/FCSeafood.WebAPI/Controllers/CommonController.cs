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
        return Ok(await _commonManager.GetCategoryTypeAsync(categoryTParams));
    }

    [HttpGet("GetCategoryBySubcategoryType")]
    public async Task<IActionResult> GetCategoryTAsync([FromQuery] SubcategoryTParams subcategoryTParams) {
        return Ok(await _commonManager.GetCategoryTypeAsync(subcategoryTParams));
    }

    [HttpGet("GetCategoryTList")]
    public async Task<IActionResult> GetCategoryTListAsync() {
        return Ok(await _commonManager.GetCategoryTListAsync());
    }

    [HttpGet("GetSubcategoryTList")]
    public async Task<IActionResult> GetSubcategoryTListAsync() {
        return Ok(await _commonManager.GetSubcategoryTListAsync());
    }

    [HttpGet("GetSubcategoryByCategoryTList")]
    public async Task<IActionResult> GetSubcategoryTListAsync([FromQuery] CategoryTParams subcategoryTParams) {
        return Ok(await _commonManager.GetSubcategoryTListAsync(subcategoryTParams));
    }

    [HttpGet("GetPaymentMethodTList")]
    public async Task<IActionResult> GetPaymentMethodTListAsync() {
        return Ok(await _commonManager.GetPaymentMethodTListAsync());
    }

    [HttpGet("GetGenderTList")]
    public async Task<IActionResult> GetGenderTListAsync() {
        return Ok(await _commonManager.GetGenderTListAsync());
    }
}