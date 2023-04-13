using FCSeafood.DAL.Events.Search;

namespace FCSeafood.DAL.Events.Repository;

public class UserRepository {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(UserRepository));

    private readonly EventFCSeafoodContext db;

    public UserRepository(EventFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<User?> GetByIdAsync(Guid id) => await db.Users.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync().ConfigureAwait(false);

    public async Task<SearchResult<User>> GetAllAsync(int skipItems = 0, int pageSize = 20) {
        var q = db.Users;
        return new SearchResult<User>(await q.Skip(skipItems).Take(pageSize).ToListAsync().ConfigureAwait(false), q.Count());
    }

    public async Task SaveAsync(User user) {
        if (!user.Equals(null)) {
            try {
                db.Users.Add(user);
                await db.SaveChangesAsync();
            } catch (Exception ex) { log.LogError($"Catch error during Add/SaveChanges to database;\r\nUser ID: [{user.Id}]\r\nError: [{ex.Message}]"); }
        }
        else { log.LogError("Failed to save user;\r\nUser: [NULL]"); }
    }

    public async Task<bool> IsExistsAsync(Guid id) => await GetByIdAsync(id) is null ? false : true;
}