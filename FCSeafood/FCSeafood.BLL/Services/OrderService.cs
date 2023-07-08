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

    public async Task<OrderModel?> InsertOrderAsync(OrderDbo orderDbo) {
        try {
            var (_, model) = await _orderRepository.InsertAsync(orderDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<OrderModel?> GetOrderAsync(Guid orderId) {
        try {
            var (_, model) = await _orderRepository.FindByConditionAsync(x => x.Id == orderId);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<OrderModel?> GetOrderByUserAsync(Guid userId) {
        try {
            var (_, model) = await _orderRepository.FindByConditionAsync(x => x.UserDboId == userId && x.IsComplete == false);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<IReadOnlyCollection<OrderModel>> GetCompleteOrderListAsync(Guid userId) {
        try {
            var (_, modelList) = await _orderRepository.FindByConditionListAsync(
                x => x.UserDboId == userId && x.IsComplete == true
            );
            return modelList;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<OrderModel>();
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

    public async Task UpdateOrderAsync(OrderModel orderModel) {
        try {
            await _orderRepository.UpdateAsync(orderModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
        }
    }

    #endregion

    #region Order Entity

    public async Task<OrderEntityModel?> InsertOrderEntityAsync(OrderEntityDbo orderEntityDbo) {
        try {
            var (_, model) = await _orderEntityRepository.InsertAsync(orderEntityDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<OrderEntityModel?> GetOrderEntityAsync(Guid orderId, Guid itemId) {
        try {
            var (_, model) = await _orderEntityRepository.FindByConditionAsync(
                x => x.OrderDboId == orderId && x.ItemDboId == itemId
            );
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task UpdateOrderEntityAsync(OrderEntityDbo orderEntityDbo) {
        try {
            await _orderEntityRepository.UpdateAsync(orderEntityDbo);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
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