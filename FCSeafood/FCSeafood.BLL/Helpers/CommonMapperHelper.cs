using AutoMapper;

namespace FCSeafood.BLL.Helpers;

public class CommonMapperHelper {
    public (bool success, CategoryTypeModel model) ToModel(DAL.Common.Models.CategoryTypeDbo dbo) {
        if (dbo.Equals(null)) return (false, new CategoryTypeModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.CategoryTypeDbo, CategoryTypeModel>()
               .ForMember(memberOptions => memberOptions.Type
                        , options => options.MapFrom(source => Enum.GetName(typeof(CategoryType), source.Id)));
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
            cfg.CreateMap<DAL.Common.Models.SubCategoryTypeDbo, SubCategoryTypeModel>()
               .ForMember(memberOptions => memberOptions.Type
                        , options => options.MapFrom(source => Enum.GetName(typeof(SubCategoryType), source.Id)));
        });
        var maper = new Mapper(config);
        var model = maper.Map<SubCategoryTypeModel>(dbo);
        return (true, model);
    }

    public (bool success, IEnumerable<SubCategoryTypeModel> models) ToModel(IEnumerable<DAL.Common.Models.SubCategoryTypeDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Enumerable.Empty<SubCategoryTypeModel>());

        var listResult = new List<SubCategoryTypeModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Enumerable.Empty<SubCategoryTypeModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }

    public (bool success, BindCategoryModel model) ToModel(DAL.Auxiliary.Models.BindCategoryDbo dbo) {
        if (dbo.Equals(null)) return (false, new BindCategoryModel());

        var model = new BindCategoryModel {
            CategoryTypeModel = EnumHelper.GetCategoryType(dbo.CategoryType)
          , SubCategoryTypeModel = EnumHelper.GetSubCategoryType(dbo.SubCategoryType)
        };
        return (true, model);
    }

    public (bool success, IEnumerable<BindCategoryModel> models) ToModel(IEnumerable<DAL.Auxiliary.Models.BindCategoryDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Enumerable.Empty<BindCategoryModel>());

        var listResult = new List<BindCategoryModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Enumerable.Empty<BindCategoryModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }
}