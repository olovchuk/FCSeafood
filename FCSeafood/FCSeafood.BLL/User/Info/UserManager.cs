namespace FCSeafood.BLL.User.Info;

public class UserManager {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(UserManager));

    private readonly UserService _userService;

    public UserManager(UserService userService) {
        _userService = userService;
    }

    public async Task<GetUserResponse> GetUser(GetUserParams getUserParams) {
        try {
            var user = await _userService.GetUserAsync(getUserParams.Id);
            if (user is null) return new GetUserResponse(false, ErrorMessage.User.IsNotDefined, null);

            return new GetUserResponse(true, "", user);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new GetUserResponse(false, ErrorMessage.User.IsNotDefined, null);
        }
    }

    public async Task<GetUserInformationResponse> GetUserInformationAsync(GetUserInformationParams getUserInformationParams) {
        try {
            var user = await _userService.GetUserAsync(getUserInformationParams.Id);
            if (user is null) return new GetUserInformationResponse(false, ErrorMessage.User.IsNotDefined, null);

            return new GetUserInformationResponse(true, "", new UserInformationModel(user.FirstName, user.LastName, user.Email, user.Role.Type));
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new GetUserInformationResponse(false, ErrorMessage.User.IsNotDefined, null);
        }
    }
}