using FCSeafood.BLL.Order;
using FCSeafood.BLL.Order.Models.Params;
using FCSeafood.BLL.User.Info.Models.Params;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase {
    private readonly OrderManager _orderManager;

    public OrderController(OrderManager orderManager) {
        _orderManager = orderManager;
    }

    [HttpPost("InsertOrderEntity")]
    public async Task<IActionResult> InsertOrderEntityAsync(OrderEntityParams orderEntityParams) {
        return Ok(await _orderManager.InsertOrderEntityAsync(orderEntityParams));
    }

    [HttpPost("IsExistsItemInOrder")]
    public async Task<IActionResult> IsExistsItemInOrder(UserItemIdsParams userItemIdsParams) {
        return Ok(await _orderManager.IsExistsItemInOrder(userItemIdsParams));
    }

    [HttpGet("GetOrderByUser")]
    public async Task<IActionResult> GetOrderByUserAsync([FromQuery] UserIdParams userIdParams) {
        var result = await _orderManager.GetOrderByUserAsync(userIdParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("RemoveOrderEntity")]
    public async Task<IActionResult> RemoveOrderEntityAsync(OrderOrderEntityIdsParams orderOrderEntityIdsParams) {
        await _orderManager.RemoveOrderEntityAsync(orderOrderEntityIdsParams);
        return Ok();
    }
}