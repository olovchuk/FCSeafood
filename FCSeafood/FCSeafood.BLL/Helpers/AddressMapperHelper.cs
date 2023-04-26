using AutoMapper;

namespace FCSeafood.BLL.Helpers;

public class AddressMapperHelper {
    public (bool success, AddressModel model) ToModel(DAL.Events.Models.AddressDbo dbo) {
        if (dbo.Equals(null)) return (false, new AddressModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.AddressDbo, AddressModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<AddressModel>(dbo);
        return (true, model);
    }
}