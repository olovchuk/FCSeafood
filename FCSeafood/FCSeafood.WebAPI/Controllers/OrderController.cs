using FCSeafood.BLL.Order;
using FCSeafood.BLL.Order.Models.Params;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase {
    private readonly OrderManager _orderManager;

    public OrderController(OrderManager orderManager) {
        _orderManager = orderManager;
    }

    [HttpGet("GetOrderByUser")]
    public async Task<IActionResult> GetOrderByUserAsync([FromQuery] OrderUserParams orderParams) {
        var result = await _orderManager.GetOrderByUserAsync(orderParams);
        if (!result.IsSuccessful)
            return BadRequest(result);

        return Ok(result);
    }
}