namespace FCSeafood.DAL.Common.Repository;

public class RoleTRepository : Base.BaseRepository<RoleTDbo> {
    public RoleTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, RoleTModel model) ToModel(RoleTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new RoleTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<RoleTModel>(dbo);
        return (true, model);
    }
}