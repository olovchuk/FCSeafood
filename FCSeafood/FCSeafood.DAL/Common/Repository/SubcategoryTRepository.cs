namespace FCSeafood.DAL.Common.Repository;

public class SubcategoryTRepository : Base.BaseRepository<SubcategoryTDbo> {
    public SubcategoryTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, SubcategoryTModel model) ToModel(SubcategoryTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new SubcategoryTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<SubcategoryTModel>(dbo);
        return (true, model);
    }

    public static (bool success, IReadOnlyCollection<SubcategoryTModel> models) ToModel(IEnumerable<SubcategoryTDbo> listDbo) {
        if (listDbo.Equals(null))
            return (false, Array.Empty<SubcategoryTModel>());

        var listResult = new List<SubcategoryTModel>();
        foreach (var result in listDbo.Select(ToModel)) {
            if (!result.success)
                return (false, Array.Empty<SubcategoryTModel>());
            listResult.Add(result.model);
        }

        return (true, listResult);
    }
}