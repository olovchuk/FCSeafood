namespace FCSeafood.BLL.Delivery;

public class DeliveryManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(DeliveryManager));

    private readonly DeliveryService _deliveryService;
    private readonly OrderService _orderService;

    public DeliveryManager(DeliveryService deliveryService, OrderService orderService) {
        _deliveryService = deliveryService;
        _orderService = orderService;
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

            var orderModel = await _orderService.GetOrderAsync(insertDeliveryParams.OrderId);
            if (orderModel is null)
                return new TrackingNumberResponse(false, ErrorMessage.Order.IsNotDefined, null);

            orderModel.IsComplete = true;
            await this._orderService.UpdateOrderAsync(orderModel);
            return new TrackingNumberResponse(true, "", deliveryModel.TrackingNumber);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new TrackingNumberResponse(false, ErrorMessage.Delivery.EntityInsertError, null);
        }
    }

    public async Task<DeliveryListResponse> GetDeliveryListAsync(UserIdParams userIdParams) {
        try {
            var deliveryModels = await _deliveryService.GetDeliveryListAsync(userIdParams.UserId);
            return new DeliveryListResponse(true, "", deliveryModels);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new DeliveryListResponse(false, ErrorMessage.Delivery.EntityInsertError, Enumerable.Empty<DeliveryModel>());
        }
    }
}