using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class UserService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(UserService));

    private readonly UserMapperHelper _userMapperHelper;
    private readonly UserRepository _userRepository;
    private readonly UserCredentialRepository _credentialRepository;

    public UserService(UserRepository userRepository, UserCredentialRepository credentialRepository, UserMapperHelper userMapperHelper) {
        _userRepository = userRepository;
        _credentialRepository = credentialRepository;
        _userMapperHelper = userMapperHelper;
    }

#region User

    public async Task<UserModel?> GetUserAsync(Guid id) {
        try {
            var userDbo = await _userRepository.FindByConditionAsync(x => x.Id == id);
            if (userDbo is null) return null;

            // TODO: Replace "ToModelAsync" to "ToModel"
            return await _userMapperHelper.ToModelAsync(userDbo);
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return null;
        }
    }

#endregion

#region Credential

    public async Task<UserCredentialModel?> GetCredentialByUserIdAsync(Guid id) {
        try {
            var userCredentialDbo = await _credentialRepository.GetByUserIdAsync(id);
            if (userCredentialDbo is null) return null;

            var result = _userMapperHelper.ToModel(userCredentialDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<UserCredentialModel?> GetCredentialByEmailAsync(string email) {
        try {
            var userCredentialDbo = await _credentialRepository.GetByEmailAsync(email);
            if (userCredentialDbo is null) return null;

            var result = _userMapperHelper.ToModel(userCredentialDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<bool> IsExistsCredentialAsync(Guid id, string email, string password) {
        try {
            return await _credentialRepository.IsExistsAsync(id, email, password);
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
            return false;
        }
    }

    public async Task SetLastLoginDateAsync(Guid id) {
        try {
            await _credentialRepository.SetLastLoginDateAsync(id);
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during a service operation;\r\nError: [{ex.Message}]");
        }
    }

#endregion
}