using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class DeliveryService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(DeliveryService));

    private readonly DeliveryRepository _deliveryRepository;

    public DeliveryService(DeliveryRepository deliveryRepository) {
        _deliveryRepository = deliveryRepository;
    }

    public async Task<DeliveryModel?> InsertDeliveryAsync(DeliveryModel deliveryModel) {
        try {
            var (_, model) = await _deliveryRepository.InsertAsync(deliveryModel);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }
}