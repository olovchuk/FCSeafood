namespace FCSeafood.DAL.Common.Repository;

public class GenderTRepository : Base.BaseRepository<GenderTDbo> {
    public GenderTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, GenderTModel model) ToModel(GenderTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new GenderTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<GenderTModel>(dbo);
        return (true, model);
    }
    
    public static (bool success, IReadOnlyCollection<GenderTModel> models) ToModel(IEnumerable<GenderTDbo> listDbo) {
        if (listDbo.Equals(null))
            return (false, Array.Empty<GenderTModel>());

        var listResult = new List<GenderTModel>();
        foreach (var result in listDbo.Select(ToModel)) {
            if (!result.success)
                return (false, Array.Empty<GenderTModel>());
            listResult.Add(result.model);
        }

        return (true, listResult);
    }
}