namespace FCSeafood.DAL.Events.Repository;

public class AddressRepository : Base.BaseRepository<AddressDbo> {
    public AddressRepository(EventFCSeafoodContext context) : base(context) { }

    public static (bool success, AddressModel model) ToModel(AddressDbo dbo) {
        if (dbo.Equals(null)) return (false, new AddressModel());

        var model = new Mapper(MapperConfig.ConfigureEvent).Map<AddressModel>(dbo);
        return (true, model);
    }

    public static (bool success, AddressDbo dbo) ToDbo(AddressModel model) {
        return model.Equals(null) ? (false, new AddressDbo()) : (true, new AddressDbo(model));
    }
}