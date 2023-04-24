namespace FCSeafood.DAL.Events.Repository;

public class AddressRepository : BaseRepository<AddressDbo> {
    public AddressRepository(EventFCSeafoodContext context) : base(context) { }
}