using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class PriceService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(PriceService));

    private readonly PriceMapperHelper _priceMapperHelper;
    private readonly PriceRepository _priceRepository;

    public PriceService(PriceMapperHelper priceMapperHelper, PriceRepository priceRepository) {
        _priceMapperHelper = priceMapperHelper;
        _priceRepository = priceRepository;
    }

    public async Task<PriceModel?> GetPriceAsync(Guid id) {
        try {
            var priceDbo = await _priceRepository.FindByConditionAsync(x => x.Id == id);
            if (priceDbo is null) return null;

            var result = _priceMapperHelper.ToModel(priceDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }
}