namespace FCSeafood.DAL.Events.Repository;

public class UserCredentialRepository : BaseRepository<UserCredentialDbo> {
    public UserCredentialRepository(EventFCSeafoodContext context) : base(context) { }
}