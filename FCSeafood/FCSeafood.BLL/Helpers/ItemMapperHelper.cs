using AutoMapper;

namespace FCSeafood.BLL.Helpers;

public class ItemMapperHelper {
    public (bool success, ItemModel model) ToModel(DAL.Events.Models.ItemDbo dbo) {
        if (dbo.Equals(null)) return (false, new ItemModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Events.Models.ItemDbo, ItemModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<ItemModel>(dbo);
        return (true, model);
    }

    public (bool success, IReadOnlyCollection<ItemModel> models) ToModel(IEnumerable<DAL.Events.Models.ItemDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<ItemModel>());

        var listResult = new List<ItemModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Array.Empty<ItemModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }
}