namespace FCSeafood.DAL.Events.Repository;

public class PriceRepository : BaseRepository<PriceDbo> {
    public PriceRepository(EventFCSeafoodContext context) : base(context) { }
}