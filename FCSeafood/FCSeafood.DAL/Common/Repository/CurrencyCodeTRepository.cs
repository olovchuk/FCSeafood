namespace FCSeafood.DAL.Common.Repository;

public class CurrencyCodeTRepository : Base.BaseRepository<CurrencyCodeTDbo> {
    public CurrencyCodeTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, CurrencyCodeTModel model) ToModel(CurrencyCodeTDbo dbo) {
        if (dbo.Equals(null)) return (false, new CurrencyCodeTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<CurrencyCodeTModel>(dbo);
        return (true, model);
    }
}