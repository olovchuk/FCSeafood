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

    [HttpGet("GetCategoryTypeList")]
    public async Task<IActionResult> GetCategoryTypeListAsync() {
        var result = await _commonManager.GetCategoryTypeListAsync();
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetSubCategoryTypeList")]
    public async Task<IActionResult> GetSubCategoryTypeListAsync() {
        var result = await _commonManager.GetSubCategoryTypeListAsync();
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetSubCategoryByCategoryTypeList")]
    public async Task<IActionResult> GetSubCategoryTypeListAsync(GetSubCategoryTypeByCategoryTypeParams subCategoryTypeByCategoryTypeParams) {
        var result = await _commonManager.GetSubCategoryTypeByCategoryTypeListAsync(subCategoryTypeByCategoryTypeParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}