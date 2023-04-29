using AutoMapper;

namespace FCSeafood.BLL.Helpers;

public class CommonMapperHelper {
    public (bool success, CategoryTModel model) ToModel(DAL.Common.Models.CategoryTDbo dbo) {
        if (dbo.Equals(null)) return (false, new CategoryTModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.CategoryTDbo, CategoryTModel>()
               .ForMember(memberOptions => memberOptions.Type
                        , options => options.MapFrom(source => Enum.GetName(typeof(CategoryType), source.Id)));
        });
        var maper = new Mapper(config);
        var model = maper.Map<CategoryTModel>(dbo);
        return (true, model);
    }

    public (bool success, IReadOnlyCollection<CategoryTModel> models) ToModel(IEnumerable<DAL.Common.Models.CategoryTDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<CategoryTModel>());

        var listResult = new List<CategoryTModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Array.Empty<CategoryTModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }

    public (bool success, SubCategoryTModel model) ToModel(DAL.Common.Models.SubCategoryTDbo dbo) {
        if (dbo.Equals(null)) return (false, new SubCategoryTModel());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<DAL.Common.Models.SubCategoryTDbo, SubCategoryTModel>()
               .ForMember(memberOptions => memberOptions.Type
                        , options => options.MapFrom(source => Enum.GetName(typeof(SubCategoryType), source.Id)));
        });
        var maper = new Mapper(config);
        var model = maper.Map<SubCategoryTModel>(dbo);
        return (true, model);
    }

    public (bool success, IReadOnlyCollection<SubCategoryTModel> models) ToModel(IEnumerable<DAL.Common.Models.SubCategoryTDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<SubCategoryTModel>());

        var listResult = new List<SubCategoryTModel>();
        foreach (var result in listDbo.Select(this.ToModel)) {
            if (!result.success) return (false, Array.Empty<SubCategoryTModel>());
            listResult.Add(result.model);
        }
        return (true, listResult);
    }

    public (bool success, BindCategoryModel model) ToModel(DAL.Auxiliary.Models.BindCategoryDbo dbo) {
        if (dbo.Equals(null)) return (false, new BindCategoryModel());

        var model = new BindCategoryModel {
            CategoryTModel = EnumHelper.GetCategoryType(dbo.CategoryType)
          , SubCategoryTModel = EnumHelper.GetSubCategoryType(dbo.SubCategoryType)
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