using AutoMapper;
using FCSeafood.BusinessObjects.Models.Events;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.User.Info.Helpers;

public class UserMapperHelper {
    private readonly AddressRepository _addressRepository;

    public UserMapperHelper(AddressRepository addressRepository) {
        _addressRepository = addressRepository;
    }

    public async Task<UserModel?> ToModelAsync(DAL.Events.Models.User dbo) {
        if (dbo.Equals(null)) return null;

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.User, UserModel>();
            cfg.CreateMap<DAL.Events.Models.Address, AddressModel>();
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

    public (bool success, UserCredentialModel model) ToModel(DAL.Events.Models.UserCredential dbo) {
        if (dbo.Equals(null)) return (false, new UserCredentialModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.UserCredential, UserCredentialModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<UserCredentialModel>(dbo);
        return (true, model);
    }
}