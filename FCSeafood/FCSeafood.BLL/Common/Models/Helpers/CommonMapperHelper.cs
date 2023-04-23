using AutoMapper;

namespace FCSeafood.BLL.Common.Models.Helpers;

public class CommonMapperHelper {
    public (bool success, CategoryTypeModel model) ToModel(DAL.Common.Models.CategoryTypeDbo dbo) {
        if (dbo.Equals(null)) return (false, new CategoryTypeModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.CategoryTypeDbo, CategoryTypeModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<CategoryTypeModel>(dbo);
        return (true, model);
    }

    public (bool success, IEnumerable<CategoryTypeModel> models) ToModel(IEnumerable<DAL.Common.Models.CategoryTypeDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Enumerable.Empty<CategoryTypeModel>());

        var listResult = new List<CategoryTypeModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Enumerable.Empty<CategoryTypeModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }

    public (bool success, SubCategoryTypeModel model) ToModel(DAL.Common.Models.SubCategoryTypeDbo dbo) {
        if (dbo.Equals(null)) return (false, new SubCategoryTypeModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.SubCategoryTypeDbo, SubCategoryTypeModel>();
        });
        var maper = new Mapper(config);
        var model = maper.Map<SubCategoryTypeModel>(dbo);
        return (true, model);
    }

    public (bool success, IEnumerable<SubCategoryTypeModel>) ToModel(IEnumerable<DAL.Common.Models.SubCategoryTypeDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Enumerable.Empty<SubCategoryTypeModel>());

        var listResult = new List<SubCategoryTypeModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Enumerable.Empty<SubCategoryTypeModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }
}