using FCSeafood.DAL.Events.Search;

namespace FCSeafood.DAL.Events.Repository;

public class UserRepository : BaseRepository<User> {
    public UserRepository(EventFCSeafoodContext context) : base(context) { }

    public async Task<bool> IsExistsAsync(Guid id) => await this.FindByConditionAsync(x => x.Id == id) is null ? false : true;
}