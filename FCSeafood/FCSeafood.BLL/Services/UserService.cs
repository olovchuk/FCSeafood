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

            var result = await _userMapperHelper.ToModel(userDbo, this);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

#endregion

#region Credential

    public async Task<string> GetUserEmailAsync(Guid id) {
        try {
            var userCredentialDbo = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            return userCredentialDbo is null ? string.Empty : userCredentialDbo.Email;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return string.Empty;
        }
    }

    public async Task<UserCredentialModel?> GetCredentialByUserIdAsync(Guid id) {
        try {
            var userCredentialDbo = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            if (userCredentialDbo is null) return null;

            var result = _userMapperHelper.ToModel(userCredentialDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<UserCredentialModel?> GetCredentialByEmailAsync(string email) {
        try {
            var userCredentialDbo = await _credentialRepository.FindByConditionAsync(x => x.Email == email);
            if (userCredentialDbo is null) return null;

            var result = _userMapperHelper.ToModel(userCredentialDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<bool> IsExistsCredentialAsync(Guid id, string email, string password) {
        try {
            var userCredentialDbo = await _credentialRepository.FindByConditionAsync(x => x.Id == id && x.Email == email && x.Password == password);
            return userCredentialDbo is not null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return false;
        }
    }

    public async Task SetLastLoginDateAsync(Guid id) {
        try {
            var userCredentialDbo = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            if (userCredentialDbo is null) return;

            userCredentialDbo.LastLoginDate = DateTime.Now;
            await _credentialRepository.UpdateAsync(userCredentialDbo);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
        }
    }

#endregion
}