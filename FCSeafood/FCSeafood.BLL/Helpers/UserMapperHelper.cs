using AutoMapper;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Helpers;

public class UserMapperHelper {
    private readonly AddressService _addressService;

    public UserMapperHelper(AddressService addressService) {
        _addressService = addressService;
    }

    public async ValueTask<(bool success, UserModel model)> ToModel(DAL.Events.Models.UserDbo dbo, UserService userService) {
        if (dbo.Equals(null)) return (false, new UserModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.UserDbo, UserModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<UserModel>(dbo);

        if (dbo.AddressId is not null) {
            var addressModel = await _addressService.GetAddressAsync(dbo.AddressId ?? Guid.Empty);
            if (addressModel is not null) model.Address = addressModel;
        }

        var email = await userService.GetUserEmailAsync(dbo.Id);
        if (!string.IsNullOrWhiteSpace(email)) model.Email = email;

        return (true, model);
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