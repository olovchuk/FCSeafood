using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class AddressService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(AddressService));

    private readonly AddressMapperHelper _addressMapperHelper;
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressMapperHelper addressMapperHelper, AddressRepository addressRepository) {
        _addressMapperHelper = addressMapperHelper;
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel?> GetAddressAsync(Guid id) {
        try {
            var addressDbo = await _addressRepository.FindByConditionAsync(x => x.Id == id);
            if (addressDbo is null) return null;

            var result = _addressMapperHelper.ToModel(addressDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return null;
        }
    }
}