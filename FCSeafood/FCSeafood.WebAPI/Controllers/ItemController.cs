using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BLL.User.Info.Models.Params;

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

    [HttpGet("GetItemRating")]
    public async Task<IActionResult> GetItemRatingAsync([FromQuery] GetItemRatingParams getItemRatingParams) {
        return Ok(await _itemManager.GetItemRatingAsync(getItemRatingParams));
    }

    [HttpGet("SetItemRating")]
    public async Task<IActionResult> SetItemRatingAsync([FromQuery] SetItemRatingParams setItemRatingParams) {
        await _itemManager.SetItemRatingAsync(setItemRatingParams);
        return Ok();
    }
}