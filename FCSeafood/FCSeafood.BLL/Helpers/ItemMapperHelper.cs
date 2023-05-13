using AutoMapper;

namespace FCSeafood.BLL.Helpers;

public class ItemMapperHelper {
    private readonly PriceService _priceService;

    public ItemMapperHelper(PriceService priceService) {
        _priceService = priceService;
    }

    public async ValueTask<(bool success, ItemModel model)> ToModel(DAL.Events.Models.ItemDbo dbo) {
        if (dbo.Equals(null)) return (false, new ItemModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.ItemDbo, ItemModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<ItemModel>(dbo);

        if (dbo.PriceId != Guid.Empty) {
            var priceModel = await _priceService.GetPriceAsync(dbo.PriceId);
            if (priceModel is not null) {
                model.Price = priceModel;
                model.Price.CurrencyCode = priceModel.CurrencyCode;
            }
        }

        model.Category = EnumHelper.GetCategoryType(dbo.CategoryType);
        model.Subcategory = EnumHelper.GetSubcategoryType(dbo.SubcategoryType);
        model.ItemStatus = EnumHelper.GetItemStatusType(dbo.ItemStatusType);
        model.TemperatureUnit = EnumHelper.GetTemperatureUnitType(dbo.TemperatureUnitType);

        return (true, model);
    }

    public async Task<(bool success, IReadOnlyCollection<ItemModel> models)> ToModel(IEnumerable<DAL.Events.Models.ItemDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<ItemModel>());

        var listResult = new List<ItemModel>();
        foreach (var dbo in listDbo) {
            var result = await this.ToModel(dbo);
            if (!result.success) return (false, Array.Empty<ItemModel>());
            listResult.Add(result.model);
        }

        return (true, listResult);
    }
}