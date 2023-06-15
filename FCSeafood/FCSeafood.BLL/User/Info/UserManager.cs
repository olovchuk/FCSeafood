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
}