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
        return Ok(await _itemManager.GetItemAsync(itemCodeParams));
    }

    [HttpGet("GetItemByFilterList")]
    public async Task<IActionResult> GetItemListAsync([FromQuery] ItemFilterParams itemByFilterParams) {
        return Ok(await _itemManager.GetItemListAsync(itemByFilterParams));
    }
}