using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class AddressService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                     .CreateLogger(typeof(AddressService));

    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository) {
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel?> InsertAddressAsync(AddressModel addressModel) {
        try {
            var result = AddressRepository.ToDbo(addressModel);
            if (!result.success)
                return null;

            var dbo = await _addressRepository.InsertAsync(result.dbo);
            if (dbo == null)
                return null;

            addressModel.Id = dbo.Id;
            return addressModel;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<AddressModel?> GetAddressAsync(Guid id) {
        try {
            var addressDbo = await _addressRepository.FindByConditionAsync(x => x.Id == id);
            if (addressDbo is null)
                return null;

            var result = AddressRepository.ToModel(addressDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }
}