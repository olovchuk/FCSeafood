using AutoMapper;
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
            var address = await _addressRepository.GetByIdAsync(addressId);
            userModel.Address = maper.Map(address, userModel.Address);
        }

        return userModel;
    }
}