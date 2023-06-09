using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Params;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase {
    private readonly ItemManager _itemManager;

    public ItemController(ItemManager itemManager) {
        _itemManager = itemManager;
    }

    [HttpGet("GetItemByCode")]
    public async Task<IActionResult> GetItemAsync([FromQuery] ItemCodeParams itemCodeParams) {
        var result = await _itemManager.GetItem(itemCodeParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("GetItemListByFilter")]
    public async Task<IActionResult> GetItemListAsync([FromQuery] ItemFilterParams itemByFilterParams) {
        var result = await _itemManager.GetItemListAsync(itemByFilterParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }
}