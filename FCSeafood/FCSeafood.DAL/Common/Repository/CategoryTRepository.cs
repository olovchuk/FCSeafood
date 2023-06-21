namespace FCSeafood.DAL.Common.Repository;

public class CategoryTRepository : Base.BaseRepository<CategoryTDbo> {
    public CategoryTRepository(CommonFCSeafoodContext context) : base(context) { }

    protected override IQueryable<CategoryTDbo> NoTracking() =>
        this.Entities
            .Include(x => x.SubcategoryTDbos)
            .AsNoTracking();

    public static (bool success, CategoryTModel model) ToModel(CategoryTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new CategoryTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<CategoryTModel>(dbo);

        var subcategoryTListModel = SubcategoryTRepository.ToModel(dbo.SubcategoryTDbos);
        if (subcategoryTListModel.success)
            model.SubcategoryTModelList = subcategoryTListModel.models.ToList();

        return (true, model);
    }

    public static (bool success, IReadOnlyCollection<CategoryTModel> models) ToModel(IEnumerable<CategoryTDbo> listDbo) {
        if (listDbo.Equals(null))
            return (false, Array.Empty<CategoryTModel>());

        var listResult = new List<CategoryTModel>();
        foreach (var result in listDbo.Select(ToModel)) {
            if (!result.success)
                return (false, Array.Empty<CategoryTModel>());
            listResult.Add(result.model);
        }

        return (true, listResult);
    }
}