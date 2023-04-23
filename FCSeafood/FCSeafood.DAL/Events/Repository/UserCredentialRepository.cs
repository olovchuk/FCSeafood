namespace FCSeafood.DAL.Events.Repository;

public class UserCredentialRepository : BaseRepository<UserCredential> {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(UserCredentialRepository));

    public UserCredentialRepository(EventFCSeafoodContext context) : base(context) { }

    public async Task<UserCredential?> GetByUserIdAsync(Guid id) => await this.FindByConditionAsync(x => x.Id == id);

    public async Task<UserCredential?> GetByEmailAsync(string email) => await this.FindByConditionAsync(uc => uc.Email == email);

    public async Task<Guid> GetUserIdByEmailAsync(string email) {
        try {
            var userCredential = await GetByEmailAsync(email);
            if (userCredential is not null && userCredential.Id != Guid.Empty) return userCredential.Id;
            return Guid.Empty;
        } catch (Exception ex) {
            _loggger.LogError($"An error was caught while manipulating the database;\r\nError: [{ex.Message}]");
            return Guid.Empty;
        }
    }

    public async Task<bool> IsExistsAsync(Guid id, string email, string password) {
        try {
            var userCredential = await this.FindByConditionAsync(x => x.Id == id);
            return userCredential is not null && userCredential.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && userCredential.Password.Equals(password, StringComparison.OrdinalIgnoreCase);
        } catch (Exception ex) {
            _loggger.LogError($"An error was caught while manipulating the database;\r\nError: [{ex.Message}]");
            return false;
        }
    }

    public async Task SetLastLoginDateAsync(Guid id) {
        try {
            var userCredential = await this.FindByConditionAsync(x => x.Id == id);
            if (userCredential is null) {
                _loggger.LogError("An error was caught while manipulating the database;\r\nError: [User credential is null]");
                return;
            }

            userCredential.LastLoginDate = DateTime.UtcNow;
            await this.UpdateAsync(userCredential);
        } catch (Exception ex) {
            _loggger.LogError($"An error was caught while manipulating the database;\r\nError: [{ex.Message}]");
        }
    }
}