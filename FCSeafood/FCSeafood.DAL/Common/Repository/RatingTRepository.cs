namespace FCSeafood.DAL.Common.Repository;

public class RatingTRepository : Base.BaseRepository<RatingTDbo> {
    public RatingTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, RatingTModel model) ToModel(RatingTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new RatingTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<RatingTModel>(dbo);
        return (true, model);
    }
}