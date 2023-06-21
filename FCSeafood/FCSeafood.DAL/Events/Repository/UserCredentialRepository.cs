namespace FCSeafood.DAL.Events.Repository;

public class UserCredentialRepository : Base.BaseRepository<UserCredentialDbo, UserCredentialModel> {
    public UserCredentialRepository(EventFCSeafoodContext context) : base(context) { }
}