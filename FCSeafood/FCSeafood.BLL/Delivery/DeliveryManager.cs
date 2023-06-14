namespace FCSeafood.BLL.Delivery;

public class DeliveryManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(DeliveryManager));

    private readonly DeliveryService _deliveryService;

    public DeliveryManager(DeliveryService deliveryService) {
        _deliveryService = deliveryService;
    }

    public async Task<DeliveryResponse> InsertDeliveryAsync(DeliveryParams deliveryParams) {
        try {
            var deliveryModel = await _deliveryService.InsertDeliveryAsync(deliveryParams.DeliveryModel);
            return new DeliveryResponse(true, "", deliveryModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new DeliveryResponse(false, ErrorMessage.Delivery.EntityInsertError, null);
        }
    }
}