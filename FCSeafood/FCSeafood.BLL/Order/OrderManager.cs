namespace FCSeafood.BLL.Order;

public class OrderManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(OrderManager));

    private readonly OrderService _orderService;

    public OrderManager(OrderService orderService) {
        _orderService = orderService;
    }

    public async Task<EmptyResponse> InsertOrderEntityAsync(OrderEntityParams orderEntityParams) {
        try {
            var orderEntity = await _orderService.InsertOrderEntityAsync(
                orderEntityParams.UserId
              , orderEntityParams.OrderEntity
            );
            if (orderEntity is null)
                return new EmptyResponse(false, ErrorMessage.Order.EntityInsertError);

            return new EmptyResponse(true, string.Empty);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new EmptyResponse(false, ErrorMessage.Order.EntityInsertError);
        }
    }

    public async Task<ExistsResponse> IsExistsItemInOrderAsync(UserItemIdsParams userItemIdsParams) {
        try {
            var isExists = await _orderService.IsExistsItemInOrderAsync(userItemIdsParams.UserId, userItemIdsParams.ItemId);
            return new ExistsResponse(true, string.Empty, isExists);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new ExistsResponse(false, string.Empty, null);
        }
    }

    public async Task<OrderResponse> GetOrderByUserAsync(UserIdParams idParams) {
        try {
            var orderModel = await _orderService.GetOrderByUserAsync(idParams.UserId);
            if (orderModel is null)
                return new OrderResponse(false, ErrorMessage.Order.IsNotDefined, null);

            return new OrderResponse(true, "", orderModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new OrderResponse(false, ErrorMessage.Order.IsNotDefined, null);
        }
    }

    public async Task RemoveOrderEntityAsync(OrderOrderEntityIdsParams orderOrderEntityIdsParams) {
        try {
            await _orderService.RemoveOrderEntityAsync(
                orderOrderEntityIdsParams.OrderId
              , orderOrderEntityIdsParams.OrderEntityId
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
        }
    }
}