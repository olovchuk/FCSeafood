namespace FCSeafood.BLL.Order;

public class OrderManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(OrderManager));

    private readonly OrderService _orderService;

    public OrderManager(OrderService orderService) {
        _orderService = orderService;
    }

    public async Task<OrderResponse> GetOrderByUserAsync(OrderUserParams orderParams) {
        try {
            var orderModel = await _orderService.GetOrderByUserAsync(orderParams.UserId);
            if (orderModel is null)
                return new OrderResponse(false, ErrorMessage.Item.IsNotDefined, null);

            return new OrderResponse(true, "", orderModel);
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new OrderResponse(false, ErrorMessage.Item.IsNotDefined, null);
        }
    }
}