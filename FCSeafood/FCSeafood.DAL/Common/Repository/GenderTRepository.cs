namespace FCSeafood.DAL.Common.Repository;

public class GenderTRepository : Base.BaseRepository<GenderTDbo> {
    public GenderTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, GenderTModel model) ToModel(GenderTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new GenderTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<GenderTModel>(dbo);
        return (true, model);
    }
}