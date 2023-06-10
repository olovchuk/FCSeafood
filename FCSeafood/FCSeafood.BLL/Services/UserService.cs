using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class UserService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(UserService));

    private readonly UserRepository _userRepository;
    private readonly UserCredentialRepository _credentialRepository;

    public UserService(UserRepository userRepository, UserCredentialRepository credentialRepository) {
        _userRepository = userRepository;
        _credentialRepository = credentialRepository;
    }

    #region User

    public async Task<UserModel?> InsertUserAsync(UserModel userModel) {
        try {
            var (_, model) = await _userRepository.InsertAsync(userModel);
            return model;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<UserModel?> InsertGuestAsync() {
        try {
            var userDbo = new UserDbo {
                FirstName = "Guest"
              , RoleTDboId = (int)RoleType.Guest
            };
            var (isSuccessful, model) = await _userRepository.InsertAsync(userDbo);
            if (isSuccessful) {
                (_, model) = await _userRepository.FindByConditionAsync(x => x.Id == model!.Id);
            }

            return model;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<UserModel?> GetUserAsync(Guid id) {
        try {
            var (_, model) = await _userRepository.FindByConditionAsync(x => x.Id == id);
            return model;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    #endregion

    #region Credential

    public async Task<UserCredentialModel?> InsertCredentialAsync(UserCredentialModel credentialModel) {
        try {
            var (_, model) = await _credentialRepository.InsertAsync(credentialModel);
            return model;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<string> GetUserEmailAsync(Guid id) {
        try {
            var (isSuccessful, model) = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            return isSuccessful ? model!.Email : string.Empty;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return string.Empty;
        }
    }

    public async Task<UserCredentialModel?> GetCredentialByUserIdAsync(Guid id) {
        try {
            var (isSuccessful, model) = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            return model;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<UserCredentialModel?> GetCredentialByEmailAsync(string email) {
        try {
            var (isSuccessful, model) = await _credentialRepository.FindByConditionAsync(x => x.Email == email);
            return model;
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task SetLastLoginDateAsync(Guid id) {
        try {
            var (isSuccessful, model) = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            if (!isSuccessful)
                return;

            model!.LastLoginDate = DateTime.Now;
            await _credentialRepository.UpdateAsync(model);
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
        }
    }

    public SignUpResponse IsValidateCredentialForSignUp(SignUpParams signUpParams) {
        if (!EmailHelper.IsValidateEmail(signUpParams.Email))
            return new SignUpResponse(false, ErrorMessage.Authentication.EmailIsNotValidate);

        if (string.IsNullOrWhiteSpace(signUpParams.Password) || signUpParams.Password.Length < 8)
            return new SignUpResponse(false, ErrorMessage.Authentication.PasswordIsNotValidate);

        if (string.IsNullOrWhiteSpace(signUpParams.FirstName) || signUpParams.FirstName.Length < 2)
            return new SignUpResponse(false, ErrorMessage.Authentication.FirstNameIsNotValidate);

        if (string.IsNullOrWhiteSpace(signUpParams.LastName) || signUpParams.LastName.Length < 2)
            return new SignUpResponse(false, ErrorMessage.Authentication.LastNameIsNotValidate);

        return new SignUpResponse(true, "");
    }

    #endregion
}