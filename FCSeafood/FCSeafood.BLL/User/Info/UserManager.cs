namespace FCSeafood.BLL.User.Info;

public class UserManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(UserManager));

    private readonly UserService _userService;

    public UserManager(UserService userService) {
        _userService = userService;
    }

    public async Task<UserResponse> GetUser(UserIdParams userIdParams) {
        try {
            var user = await _userService.GetUserAsync(userIdParams.UserId);
            if (user is null)
                return new UserResponse(false, ErrorMessage.User.IsNotDefined, null);

            return new UserResponse(true, "", user);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new UserResponse(false, ErrorMessage.User.IsNotDefined, null);
        }
    }

    public async Task<CredentialResponse> GetUserCredentialsAsync(UserIdParams userIdParams) {
        try {
            var credential = await _userService.GetCredentialByUserIdAsync(userIdParams.UserId);
            if (credential is null)
                return new CredentialResponse(false, ErrorMessage.User.IsNotDefined, null);

            return new CredentialResponse(true, "", credential);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new CredentialResponse(false, ErrorMessage.User.IsNotDefined, null);
        }
    }

    public async Task<UserInformationResponse> GetUserInformationAsync(UserIdParams userIdParams) {
        try {
            var user = await _userService.GetUserAsync(userIdParams.UserId);
            if (user is null)
                return new UserInformationResponse(false, ErrorMessage.User.IsNotDefined, null);

            return new UserInformationResponse(
                true
              , ""
              , new UserInformationModel(
                    user.FirstName
                  , user.LastName
                  , user.Email
                  , user.Role.Type
                )
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new UserInformationResponse(false, ErrorMessage.User.IsNotDefined, null);
        }
    }

    public async Task UpdateUserAddressAsync(UpdateUserAddressParams updateUserAddressParams) {
        try {
            await _userService.UpdateUserAddressAsync(updateUserAddressParams.UserId, updateUserAddressParams.AddressModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
        }
    }

    public async Task UpdateUserInformationAsync(UpdateUserInformationParams updateUserInformationParams) {
        try {
            var user = await _userService.GetUserAsync(updateUserInformationParams.UserId);
            if (user is null)
                return;

            user.FirstName = updateUserInformationParams.FirstName;
            user.LastName = updateUserInformationParams.LastName;
            user.Gender.Type = updateUserInformationParams.GenderType;
            user.Phone = updateUserInformationParams.Phone;
            user.DateOfBirth = updateUserInformationParams.DateOfBirth;
            await _userService.UpdateUserAsync(user);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
        }
    }
}