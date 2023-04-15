using AutoMapper;

namespace FCSeafood.BLL.Common.Models.Helpers;

public class CommonMapperHelper {
    public CategoryTypeModel? ToModel(DAL.Common.Models.CategoryTypeDbo dbo) {
        if (dbo.Equals(null)) return null;

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.CategoryTypeDbo, CategoryTypeModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<CategoryTypeModel>(dbo);
        return model;
    }

    public List<CategoryTypeModel>? ToModel(List<DAL.Common.Models.CategoryTypeDbo> listDbo) {
        if (listDbo.Equals(null)) return null;

        var listResult = new List<CategoryTypeModel>();
        foreach (var model in listDbo.Select(this.ToModel)) {
            if (model == null) return null;
            listResult.Add(model);
        }
        return listResult;
    }
}