using FCSeafood.BLL.Delivery;
using FCSeafood.BLL.Delivery.Models.Params;
using FCSeafood.BLL.User.Info.Models.Params;

namespace FCSeafood.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeliveryController : ControllerBase {
    private readonly DeliveryManager _deliveryManager;

    public DeliveryController(DeliveryManager deliveryManager) {
        _deliveryManager = deliveryManager;
    }

    [HttpPost("InsertDelivery")]
    public async Task<IActionResult> InsertDeliveryAsync(InsertDeliveryParams insertDeliveryParams) {
        return Ok(await _deliveryManager.InsertDeliveryAsync(insertDeliveryParams));
    }

    [HttpGet("GetDeliveryList")]
    public async Task<IActionResult> GetDeliveryListAsync([FromQuery] UserIdParams userIdParams) {
        return Ok(await _deliveryManager.GetDeliveryListAsync(userIdParams));
    }
}