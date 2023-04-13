namespace FCSeafood.DAL.Events.Repository;

public class UserCredentialRepository {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(UserCredentialRepository));

    private readonly EventFCSeafoodContext db;

    public UserCredentialRepository(EventFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<UserCredential?> GetByUserIdAsync(Guid userId) => await db.UserCredentials.Where(uc => uc.Id == userId).FirstOrDefaultAsync().ConfigureAwait(false);

    public async Task<UserCredential?> GetByEmailAsync(string email) => await db.UserCredentials.Where(uc => uc.Email == email).FirstOrDefaultAsync().ConfigureAwait(false);

    public async Task<Guid> GetUserIdByEmailAsync(string email) {
        var userCredential = await GetByEmailAsync(email);
        if (userCredential is not null && userCredential.Id != Guid.Empty) return userCredential.Id;

        log.LogError($"Failed to get user id by email;\r\nEmail: [{email}]");
        return Guid.Empty;
    }

    public async Task<bool> IsExistsAsync(Guid userId, string email, string password) {
        var userCredential = await GetByUserIdAsync(userId);
        return userCredential is not null && userCredential.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && userCredential.Password.Equals(password, StringComparison.OrdinalIgnoreCase);
    }

    public async Task SetLastLoginDateAsync(Guid id) {
        var userCredential = await GetByUserIdAsync(id);
        if (userCredential is null) {
            log.LogWarning($"Warning with set last login date;\r\nUser Id: [{id}]\r\nUser credential: [NULL]");
            return;
        }

        userCredential.LastLoginDate = DateTime.UtcNow;
        await db.SaveChangesAsync();
    }
}