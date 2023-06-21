using FCSeafood.BLL.Delivery;
using FCSeafood.BLL.Delivery.Models.Params;

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
}