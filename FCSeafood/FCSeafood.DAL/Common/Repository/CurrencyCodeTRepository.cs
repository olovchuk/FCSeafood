namespace FCSeafood.DAL.Common.Repository;

public class CurrencyCodeTRepository : BaseRepository<CurrencyCodeTDbo> {
    public CurrencyCodeTRepository(EventFCSeafoodContext context) : base(context) { }
}