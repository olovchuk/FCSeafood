namespace FCSeafood.DAL.Common.Repository;

public class TemperatureUnitTRepository : Base.BaseRepository<TemperatureUnitTDbo> {
    public TemperatureUnitTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, TemperatureUnitTModel model) ToModel(TemperatureUnitTDbo dbo) {
        if (dbo.Equals(null)) return (false, new TemperatureUnitTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<TemperatureUnitTModel>(dbo);
        return (true, model);
    }
}