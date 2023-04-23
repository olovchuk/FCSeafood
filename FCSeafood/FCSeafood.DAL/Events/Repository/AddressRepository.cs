namespace FCSeafood.DAL.Events.Repository;

public class AddressRepository : BaseRepository<Address> {
    public AddressRepository(EventFCSeafoodContext context) : base(context) { }
}