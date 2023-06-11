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
    public async Task<IActionResult> IsExistsItemInOrderAsync(UserItemIdsParams userItemIdsParams) {
        return Ok(await _orderManager.IsExistsItemInOrderAsync(userItemIdsParams));
    }

    [HttpGet("GetOrderByUser")]
    public async Task<IActionResult> GetOrderByUserAsync([FromQuery] UserIdParams userIdParams) {
        return Ok(await _orderManager.GetOrderByUserAsync(userIdParams));
    }

    [HttpPost("RemoveOrderEntity")]
    public async Task<IActionResult> RemoveOrderEntityAsync(OrderOrderEntityIdsParams orderOrderEntityIdsParams) {
        await _orderManager.RemoveOrderEntityAsync(orderOrderEntityIdsParams);
        return Ok();
    }
}