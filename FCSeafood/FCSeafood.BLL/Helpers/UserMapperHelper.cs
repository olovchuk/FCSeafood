using AutoMapper;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Helpers;

public class UserMapperHelper {
    private readonly AddressRepository _addressRepository;

    public UserMapperHelper(AddressRepository addressRepository) {
        _addressRepository = addressRepository;
    }

    public async Task<UserModel?> ToModelAsync(DAL.Events.Models.UserDbo dbo) {
        if (dbo.Equals(null)) return null;

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.UserDbo, UserModel>();
            cfg.CreateMap<DAL.Events.Models.AddressDbo, AddressModel>();
        });
        var maper = new Mapper(config);
        var userModel = maper.Map<UserModel>(dbo);

        if (dbo.AddressId is not null) {
            var addressId = dbo.AddressId ?? Guid.Empty;

            // TODO: Use address service
            var address = await _addressRepository.FindByConditionAsync(x => x.Id == addressId);
            userModel.Address = maper.Map(address, userModel.Address);
        }

        return userModel;
    }

    public (bool success, UserCredentialModel model) ToModel(DAL.Events.Models.UserCredentialDbo dbo) {
        if (dbo.Equals(null)) return (false, new UserCredentialModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.UserCredentialDbo, UserCredentialModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<UserCredentialModel>(dbo);
        return (true, model);
    }
}