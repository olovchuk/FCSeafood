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

    [HttpGet("GetOrderByUser")]
    public async Task<IActionResult> GetOrderByUserAsync([FromQuery] UserIdParams userIdParams) {
        return Ok(await _orderManager.GetOrderByUserAsync(userIdParams));
    }

    [HttpGet("GetOrderCountByUser")]
    public async Task<IActionResult> GetOrderCountByUser([FromQuery] UserIdParams userIdParams) {
        return Ok(await _orderManager.GetOrderCountByUser(userIdParams));
    }

    [HttpPost("RemoveOrderEntity")]
    public async Task<IActionResult> RemoveOrderEntityAsync(OrderOrderEntityIdsParams orderOrderEntityIdsParams) {
        await _orderManager.RemoveOrderEntityAsync(orderOrderEntityIdsParams);
        return Ok();
    }
}