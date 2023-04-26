using FCSeafood.DAL.Events.Search;

namespace FCSeafood.DAL.Events.Repository;

public class UserRepository : BaseRepository<UserDbo> {
    public UserRepository(EventFCSeafoodContext context) : base(context) { }
}