using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Params;
using Microsoft.AspNetCore.Authorization;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase {
    private readonly ItemManager _itemManager;

    public ItemController(ItemManager itemManager) {
        _itemManager = itemManager;
    }

    [HttpGet("GetItemByFilterList")]
    public async Task<IActionResult> GetItemListAsync([FromQuery]ItemByFilterParams itemByFilterParams) {
        var result = await _itemManager.GetItemListAsync(itemByFilterParams);
        if (!result.IsSuccessful) return BadRequest(result);

        return Ok(result);
    }
}