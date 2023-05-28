namespace FCSeafood.DAL.Events.Repository;

public class UserRepository : Base.BaseRepository<UserDbo> {
    public UserRepository(EventFCSeafoodContext context) : base(context) { }
    protected override IQueryable<UserDbo> NoTracking() => this.Entities.Include(x => x.RoleTDbo).Include(x => x.GenderTDbo).Include(x => x.AddressDbo).AsNoTracking();

    public static (bool success, UserModel model) ToModel(UserDbo dbo) {
        if (dbo.Equals(null)) return (false, new UserModel());

        var model = new Mapper(MapperConfig.ConfigureEvent).Map<UserModel>(dbo);

        if (dbo.RoleTDbo != null) {
            var result = RoleTRepository.ToModel(dbo.RoleTDbo);
            if (result.success) model.Role = result.model;
        }

        if (dbo.GenderTDbo != null) {
            var result = GenderTRepository.ToModel(dbo.GenderTDbo);
            if (result.success) model.Gender = result.model;
        }

        if (dbo.AddressDbo != null) {
            var result = AddressRepository.ToModel(dbo.AddressDbo);
            if (result.success) model.Address = result.model;
        }

        return (true, model);
    }

    public static (bool success, UserDbo dbo) ToDbo(UserModel model) {
        return model.Equals(null) ? (false, new UserDbo()) : (true, new UserDbo(model));
    }
}