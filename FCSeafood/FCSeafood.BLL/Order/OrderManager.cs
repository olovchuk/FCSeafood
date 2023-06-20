using FCSeafood.DAL.Events.Models;

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
            if (orderEntityParams.UserId == Guid.Empty)
                return new EmptyResponse(false, ErrorMessage.User.IsNotDefined);

            var isChangePrice = true;
            var orderModel = await _orderService.GetOrderByUserAsync(orderEntityParams.UserId);
            if (orderModel is null) {
                isChangePrice = false;
                var orderDbo = new OrderDbo {
                    UserDboId = orderEntityParams.UserId
                  , TotalPrice = orderEntityParams.OrderEntity.Price
                  , CreatedDate = DateTime.Now
                };

                orderModel = await _orderService.InsertOrderAsync(orderDbo);
                if (orderModel is null)
                    return new EmptyResponse(false, ErrorMessage.Order.EntityInsertError);
            }

            var orderEntityModel = await _orderService.GetOrderEntityAsync(
                orderModel.Id
              , orderEntityParams.OrderEntity.Item.Id
            );
            if (orderEntityModel is not null) {
                orderEntityParams.OrderEntity.Id = orderEntityModel.Id;
                if (isChangePrice) {
                    orderModel.TotalPrice -= orderEntityModel.Price;
                    orderModel.TotalPrice += orderEntityParams.OrderEntity.Price;
                    await _orderService.UpdateOrderAsync(orderModel);
                }

                var orderEntityDbo = new OrderEntityDbo(orderEntityParams.OrderEntity) {
                    OrderDboId = orderModel.Id
                };
                await _orderService.UpdateOrderEntityAsync(orderEntityDbo);
                return new EmptyResponse(true, string.Empty);
            }

            var entityDbo = new OrderEntityDbo(orderEntityParams.OrderEntity) {
                OrderDboId = orderModel.Id
            };
            orderEntityModel = await _orderService.InsertOrderEntityAsync(entityDbo);
            if (orderEntityModel is null)
                return new EmptyResponse(false, ErrorMessage.Order.EntityInsertError);

            if (isChangePrice) {
                orderModel.TotalPrice += entityDbo.Price;
                await _orderService.UpdateOrderAsync(orderModel);
            }

            return new EmptyResponse(true, string.Empty);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new EmptyResponse(false, ErrorMessage.Order.EntityInsertError);
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

    public async Task<CountResponse> GetOrderCountByUser(UserIdParams idParams) {
        try {
            var orderCount = await _orderService.GetOrderCountByUser(idParams.UserId);
            return new CountResponse(true, "", orderCount);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new CountResponse(false, ErrorMessage.Order.IsNotDefined, null);
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