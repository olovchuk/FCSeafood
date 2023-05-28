namespace FCSeafood.DAL.Events.Repository;

public class UserCredentialRepository : Base.BaseRepository<UserCredentialDbo> {
    public UserCredentialRepository(EventFCSeafoodContext context) : base(context) { }

    public static (bool success, UserCredentialModel model) ToModel(UserCredentialDbo dbo) {
        if (dbo.Equals(null)) return (false, new UserCredentialModel());

        var model = new Mapper(MapperConfig.ConfigureEvent).Map<UserCredentialModel>(dbo);
        return (true, model);
    }

    public static (bool success, UserCredentialDbo dbo) ToDbo(UserCredentialModel model) {
        return model.Equals(null) ? (false, new UserCredentialDbo()) : (true, new UserCredentialDbo(model));
    }
}