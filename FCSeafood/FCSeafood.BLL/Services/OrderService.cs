using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class OrderService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(OrderService));

    private readonly OrderRepository _orderRepository;
    private readonly OrderEntityRepository _orderEntityRepository;

    public OrderService(OrderRepository orderRepository, OrderEntityRepository orderEntityRepository) {
        _orderRepository = orderRepository;
        _orderEntityRepository = orderEntityRepository;
    }

    #region Order

    public async Task<bool> IsExistsItemInOrderAsync(Guid userId, Guid itemId) {
        var (isSuccessful, model) = await _orderRepository.FindByConditionAsync(x => x.UserDboId == userId);
        if (!isSuccessful)
            return false;

        return model!.Orders.FirstOrDefault(x => x.Item.Id == itemId) is not null;
    }

    public async Task<OrderModel?> GetOrderByUserAsync(Guid userId) {
        try {
            var (_, model) = await _orderRepository.FindByConditionAsync(x => x.UserDboId == userId);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<int> GetOrderCountByUser(Guid userId) {
        try {
            var (isSuccessful, model) = await _orderRepository.FindByConditionAsync(x => x.UserDboId == userId);
            return isSuccessful ? 0 : model!.Orders.Count;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return 0;
        }
    }

    #endregion

    #region Order Entity

    public async Task<OrderEntityModel?> InsertOrderEntityAsync(Guid userId, OrderEntityModel orderEntityModel) {
        try {
            if (userId == Guid.Empty)
                return null;

            var isChangePrice = true;
            var (isSuccessful, orderModel) = await _orderRepository.FindByConditionAsync(x => x.UserDboId == userId);
            if (!isSuccessful) {
                isChangePrice = false;
                var orderDbo = new OrderDbo {
                    UserDboId = userId
                  , TotalPrice = orderEntityModel.Price
                  , CreatedDate = DateTime.Now
                };

                (isSuccessful, orderModel) = await _orderRepository.InsertAsync(orderDbo);
                if (!isSuccessful)
                    return null;
            }

            var isExistsItemInOrder = await IsExistsItemInOrderAsync(orderModel!.Id, orderEntityModel.Item.Id);
            if (isExistsItemInOrder)
                return null;

            (isSuccessful, var entityDbo) = _orderEntityRepository.ToDbo(orderEntityModel);
            if (!isSuccessful)
                return null;

            entityDbo!.OrderDboId = orderModel.Id;
            (isSuccessful, var model) = await _orderEntityRepository.InsertAsync(entityDbo);
            if (!isSuccessful)
                return null;

            if (isChangePrice) {
                orderModel.TotalPrice += entityDbo.Price;
                await _orderRepository.UpdateAsync(orderModel);
            }

            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task RemoveOrderEntityAsync(Guid orderId, Guid orderEntityId) {
        if (orderId == Guid.Empty || orderEntityId == Guid.Empty)
            return;

        var (isSuccessful, orderModel) = await _orderRepository.FindByConditionAsync(x => x.Id == orderId);
        if (!isSuccessful)
            return;

        var entityModel = orderModel!.Orders.FirstOrDefault(x => x.Id == orderEntityId);
        if (entityModel == null)
            return;

        orderModel.TotalPrice -= entityModel.Price;
        await _orderRepository.UpdateAsync(orderModel);

        await _orderEntityRepository.RemoveAsync(entityModel);
    }

    #endregion
}