using AutoMapper;
using FCSeafood.DAL.Events.Models;

namespace FCSeafood.BLL.Helpers;

public class AddressMapperHelper {
    public (bool success, AddressModel model) ToModel(AddressDbo dbo) {
        if (dbo.Equals(null)) return (false, new AddressModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<AddressDbo, AddressModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<AddressModel>(dbo);
        return (true, model);
    }

    public (bool success, AddressDbo dbo) ToDbo(AddressModel model) {
        if (model.Equals(null)) return (false, new AddressDbo());

        return (true, new AddressDbo(model));
    }
}