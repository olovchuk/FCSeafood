using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class AddressService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(AddressService));

    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository) {
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel?> InsertAddressAsync(AddressModel addressModel) {
        try {
            var (_, model) = await _addressRepository.InsertAsync(addressModel);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<AddressModel?> GetAddressAsync(Guid id) {
        try {
            var (_, model) = await _addressRepository.FindByConditionAsync(x => x.Id == id);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }
}