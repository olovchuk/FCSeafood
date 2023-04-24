using AutoMapper;

namespace FCSeafood.BLL.Helpers;

public class CommonMapperHelper {
    public (bool success, CategoryTypeModel model) ToModel(DAL.Common.Models.CategoryTDbo dbo) {
        if (dbo.Equals(null)) return (false, new CategoryTypeModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.CategoryTDbo, CategoryTypeModel>()
               .ForMember(memberOptions => memberOptions.Type
                        , options => options.MapFrom(source => Enum.GetName(typeof(CategoryType), source.Id)));
        });
        var maper = new Mapper(config);
        var model = maper.Map<CategoryTypeModel>(dbo);
        return (true, model);
    }

    public (bool success, IReadOnlyCollection<CategoryTypeModel> models) ToModel(IEnumerable<DAL.Common.Models.CategoryTDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<CategoryTypeModel>());

        var listResult = new List<CategoryTypeModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Array.Empty<CategoryTypeModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }

    public (bool success, SubCategoryTypeModel model) ToModel(DAL.Common.Models.SubCategoryTDbo dbo) {
        if (dbo.Equals(null)) return (false, new SubCategoryTypeModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.SubCategoryTDbo, SubCategoryTypeModel>()
               .ForMember(memberOptions => memberOptions.Type
                        , options => options.MapFrom(source => Enum.GetName(typeof(SubCategoryType), source.Id)));
        });
        var maper = new Mapper(config);
        var model = maper.Map<SubCategoryTypeModel>(dbo);
        return (true, model);
    }

    public (bool success, IReadOnlyCollection<SubCategoryTypeModel> models) ToModel(IEnumerable<DAL.Common.Models.SubCategoryTDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<SubCategoryTypeModel>());

        var listResult = new List<SubCategoryTypeModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Array.Empty<SubCategoryTypeModel>());
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

    public (bool success, IReadOnlyCollection<BindCategoryModel> models) ToModel(IEnumerable<DAL.Auxiliary.Models.BindCategoryDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<BindCategoryModel>());

        var listResult = new List<BindCategoryModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Array.Empty<BindCategoryModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }
}