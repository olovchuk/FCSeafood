namespace FCSeafood.DAL.Events.Repository;

public class AddressRepository : Base.BaseRepository<AddressDbo, AddressModel> {
    public AddressRepository(EventFCSeafoodContext context) : base(context) { }
}