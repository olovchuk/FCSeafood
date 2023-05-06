using AutoMapper;

namespace FCSeafood.BLL.Helpers;

public class PriceMapperHelper {
    public (bool success, PriceModel model) ToModel(DAL.Events.Models.PriceDbo dbo) {
        if (dbo.Equals(null)) return (false, new PriceModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.PriceDbo, PriceModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<PriceModel>(dbo);

        model.CurrencyCode = EnumHelper.GetCurrencyCodeType(dbo.CurrencyCodeType);

        return (true, model);
    }
}