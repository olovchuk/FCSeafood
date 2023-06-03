using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class PriceService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                     .CreateLogger(typeof(PriceService));

    private readonly PriceRepository _priceRepository;

    public PriceService(PriceRepository priceRepository) {
        _priceRepository = priceRepository;
    }

    public async Task<PriceModel?> GetPriceAsync(Guid id) {
        try {
            var priceDbo = await _priceRepository.FindByConditionAsync(x => x.Id == id);
            if (priceDbo is null)
                return null;

            var result = PriceRepository.ToModel(priceDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }
}