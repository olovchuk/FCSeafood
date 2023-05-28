namespace FCSeafood.DAL.Events.Repository;

public class PriceRepository : Base.BaseRepository<PriceDbo> {
    public PriceRepository(EventFCSeafoodContext context) : base(context) { }

    protected override IQueryable<PriceDbo> NoTracking() => this.Entities.Include(x => x.CurrencyCodeTDbo).AsNoTracking();

    public static (bool success, PriceModel model) ToModel(PriceDbo dbo) {
        if (dbo.Equals(null)) return (false, new PriceModel());

        var model = new Mapper(MapperConfig.ConfigureEvent).Map<PriceModel>(dbo);

        if (dbo.CurrencyCodeTDbo != null) {
            var result = CurrencyCodeTRepository.ToModel(dbo.CurrencyCodeTDbo);
            if (result.success) model.CurrencyCode = result.model;
        }

        return (true, model);
    }
}