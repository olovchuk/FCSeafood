namespace FCSeafood.BLL.Order;

public class OrderManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(OrderManager));

    private readonly OrderService _orderService;

    public OrderManager(OrderService orderService) {
        _orderService = orderService;
    }

    public async Task<OrderListResponse> GetOrderByUserAsync(OrderParams orderParams) {
        try {
            var orderModel = await _orderService.GetOrderByUserAsync(orderParams.UserId);
            if (orderModel is null)
                return new OrderListResponse(false, ErrorMessage.Item.IsNotDefined, null);

            return new OrderListResponse(true, "", orderModel);
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new OrderListResponse(false, ErrorMessage.Item.IsNotDefined, null);
        }
    }
}