using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class UserService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(UserService));

    private readonly UserRepository _userRepository;
    private readonly UserCredentialRepository _credentialRepository;
    private readonly AddressRepository _addressRepository;
    private readonly ResetPasswordLRepository _resetPasswordLRepository;

    public UserService(
        UserRepository userRepository
      , UserCredentialRepository credentialRepository
      , AddressRepository addressRepository
      , ResetPasswordLRepository resetPasswordLRepository
    ) {
        _userRepository = userRepository;
        _credentialRepository = credentialRepository;
        _addressRepository = addressRepository;
        _resetPasswordLRepository = resetPasswordLRepository;
    }

    #region User

    public async Task<UserModel?> InsertUserAsync(UserModel userModel) {
        try {
            var (_, model) = await _userRepository.InsertAsync(userModel);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
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
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<UserModel?> GetUserAsync(Guid id) {
        try {
            var (_, model) = await _userRepository.FindByConditionAsync(x => x.Id == id);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<UserModel?> GetUserByEmailAsync(string email) {
        try {
            var credential = await GetCredentialByEmailAsync(email);
            if (credential is null)
                return null;

            return await GetUserAsync(credential.Id);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task UpdateUserAsync(UserModel userModel) {
        try {
            await _userRepository.UpdateAsync(userModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
        }
    }

    public async Task UpdateUserAddressAsync(Guid userId, AddressModel addressModel) {
        try {
            var (isSuccessful, model) = await _userRepository.FindByConditionAsync(x => x.Id == userId);
            if (!isSuccessful)
                return;

            if (model!.Address == null) {
                (isSuccessful, var newAddressModel) = await _addressRepository.InsertAsync(addressModel);
                if (!isSuccessful)
                    return;

                model.Address = newAddressModel;
                await _userRepository.UpdateAsync(model);
                return;
            }

            (isSuccessful, var addressModelUpdate) = await _addressRepository.FindByConditionAsync(x => x.Id == model.Address.Id);
            if (!isSuccessful)
                return;

            addressModel.Id = addressModelUpdate!.Id;
            await _addressRepository.UpdateAsync(addressModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
        }
    }

    public async Task<int> GetCodeForResetPassword(Guid userId) {
        try {
            var code = new Random().Next(100000, 999999);
            var resetPasswordLDbo = new ResetPasswordLDbo {
                UserDboId = userId
              , Code = code
              , CreatedDate = DateTime.Now
              , ExpirationDate = DateTime.Now.AddMinutes(10)
            };

            var (isSuccessful, model) = await _resetPasswordLRepository.InsertAsync(resetPasswordLDbo);
            return !isSuccessful ? 0 : code;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return 0;
        }
    }

    public async Task RemoveAllCodesForResetPasswordAsync(Guid userId) {
        try {
            var (isSuccessful, models) = await _resetPasswordLRepository.FindByConditionListAsync(x => x.UserDboId == userId);
            if (!isSuccessful)
                return;

            await _resetPasswordLRepository.RemoveRangeAsync(models);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
        }
    }

    public async Task<bool> IsUserHaveCodesForResetPasswordAsync(Guid userId) {
        try {
            var (isSuccessful, models) = await _resetPasswordLRepository.FindByConditionListAsync(x => x.UserDboId == userId);
            if (!isSuccessful)
                return false;

            return models.Count > 0;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return false;
        }
    }

    #endregion

    #region Credential

    public async Task<UserCredentialModel?> InsertCredentialAsync(UserCredentialModel credentialModel) {
        try {
            var (_, model) = await _credentialRepository.InsertAsync(credentialModel);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<string> GetUserEmailAsync(Guid id) {
        try {
            var (isSuccessful, model) = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            return isSuccessful ? model!.Email : string.Empty;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return string.Empty;
        }
    }

    public async Task<UserCredentialModel?> GetCredentialByUserIdAsync(Guid id) {
        try {
            var (_, model) = await _credentialRepository.FindByConditionAsync(x => x.Id == id);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<UserCredentialModel?> GetCredentialByEmailAsync(string email) {
        try {
            var (_, model) = await _credentialRepository.FindByConditionAsync(x => x.Email == email);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
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
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
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

    public async Task UpdateUserPassword(Guid userId, string newPasswordHash) {
        try {
            var (isSuccessful, model) = await _credentialRepository.FindByConditionAsync(x => x.Id == userId);
            if (!isSuccessful)
                return;

            model!.Password = newPasswordHash;
            await _credentialRepository.UpdateAsync(model);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
        }
    }

    #endregion
}