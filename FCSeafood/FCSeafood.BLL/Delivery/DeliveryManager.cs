namespace FCSeafood.BLL.Delivery;

public class DeliveryManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(DeliveryManager));

    private readonly DeliveryService _deliveryService;

    public DeliveryManager(DeliveryService deliveryService) {
        _deliveryService = deliveryService;
    }

    public async Task<TrackingNumberResponse> InsertDeliveryAsync(InsertDeliveryParams insertDeliveryParams) {
        try {
            var deliveryModel = await _deliveryService.InsertDeliveryAsync(
                insertDeliveryParams.UserId
              , insertDeliveryParams.OrderId
              , insertDeliveryParams.PaymentMethodType
              , insertDeliveryParams.Notes
            );
            if (deliveryModel is null)
                return new TrackingNumberResponse(false, ErrorMessage.Delivery.EntityInsertError, null);

            return new TrackingNumberResponse(true, "", deliveryModel.TrackingNumber);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new TrackingNumberResponse(false, ErrorMessage.Delivery.EntityInsertError, null);
        }
    }
}