using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class DeliveryService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(DeliveryService));

    private readonly DeliveryRepository _deliveryRepository;

    public DeliveryService(DeliveryRepository deliveryRepository) {
        _deliveryRepository = deliveryRepository;
    }

    public async Task<DeliveryModel?> InsertDeliveryAsync(
        Guid userId
      , Guid orderId
      , PaymentMethodType paymentMethodType
      , string? notes
    ) {
        try {
            var deliveryDbo = new DeliveryDbo {
                TrackingNumber = GenerateTrackingNumber()
              , UserDboId = userId
              , OrderDboId = orderId
              , DeliveryStatusTDboId = (int)DeliveryStatusType.Pending
              , PaymentMethodTDboId = (int)paymentMethodType
              , Notes = notes
            };
            var (_, model) = await _deliveryRepository.InsertAsync(deliveryDbo);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<IReadOnlyCollection<DeliveryModel>> GetDeliveryListAsync(Guid userId) {
        try {
            var (_, models) = await _deliveryRepository.FindByConditionListAsync(x => x.UserDboId == userId);
            return models;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<DeliveryModel>();
        }
    }

    private string GenerateTrackingNumber() {
        var uniqueId = Guid.NewGuid().ToString("N");
        const string format = "ddMMyyyy-hhmm-ss-";
        return DateTime.Now.ToString(format) + uniqueId;
    }
}