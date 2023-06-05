using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class OrderService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(OrderService));

    private readonly OrderRepository _orderRepository;

    public OrderService(OrderRepository orderRepository) {
        _orderRepository = orderRepository;
    }

    public async Task<OrderModel?> GetOrderByUserAsync(Guid userId) {
        try {
            var (_, model) = await _orderRepository.FindByConditionAsync(x => x.UserDboId == userId);
            return model;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }
}