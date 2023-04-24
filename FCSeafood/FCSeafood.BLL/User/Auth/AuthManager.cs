using System.IdentityModel.Tokens.Jwt;

namespace FCSeafood.BLL.User.Auth;

public class AuthManager {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(AuthManager));

    // TODO: Set support email from global settings
    private const string GlobalMessageError = "Authentication failed. Please please try to sign in again or contact us via [Email]";

    private readonly UserService _userService;
    private readonly AuthJwtHelper _authJwtHelper;
    private readonly AuthRefreshJwtHelper _authRefreshJwtHelper;

    public AuthManager(AuthJwtHelper authJwtHelper, AuthRefreshJwtHelper authRefreshJwtHelper, UserService userService) {
        _authJwtHelper = authJwtHelper;
        _authRefreshJwtHelper = authRefreshJwtHelper;
        _userService = userService;
    }

    public async Task<SignInResponse> SignInAsync(SignInParams singInParams) {
        var errorResponse = new SignInResponse(false, "Email or Password incorrect. Please try again.", RoleType.Unknown, null);
        try {
            var userCredential = await _userService.GetCredentialByEmailAsync(singInParams.Email);
            if (userCredential is null) return errorResponse;

            var user = await _userService.GetUserAsync(userCredential.Id);
            if (user is null) return errorResponse;

            var valid = await _userService.IsExistsCredentialAsync(userCredential.Id, singInParams.Email, singInParams.Password);
            if (!valid) return errorResponse;

            var refreshUserResult = await RefreshUserAsync(new RefreshUserParams(user, userCredential.Email));
            if (!refreshUserResult.IsSuccessful) return new SignInResponse(false, refreshUserResult.Message, RoleType.Unknown, null);

            var jwtAuthModel = new JwtAuthModel(refreshUserResult.JwtAuthModel?.AccessToken!, refreshUserResult.JwtAuthModel?.RefreshToken!);
            return new SignInResponse(true, "", refreshUserResult.RoleType, jwtAuthModel);
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during management;\r\nError: [{ex.Message}]");
            return new SignInResponse(false, GlobalMessageError, RoleType.Unknown, null);
        }
    }

    public async Task<SignInRefreshResponse> SignInRefreshAsync(SignInRefreshParams signInRefreshParams) {
        var errorResponse = new SignInRefreshResponse(false, GlobalMessageError, null);
        try {
            var token = _authJwtHelper.Validate(signInRefreshParams.RefreshToken);
            if (token is null) return errorResponse;

            var claimsValues = JwtClaimsHelper.GetUserClaims(token.Claims);
            if (!claimsValues.IsValid) return errorResponse;

            var user = await _userService.GetUserAsync(claimsValues.UserId);
            if (user is null) return errorResponse;

            var credential = await _userService.GetCredentialByUserIdAsync(user.Id);
            if (credential is null) return errorResponse;

            var accessToken = _authJwtHelper.GenerateJwt(user.Id, credential.Email, user.RoleType);
            var refreshToken = _authRefreshJwtHelper.GenerateJwt(user.Id, credential.Email, user.RoleType);

            return new SignInRefreshResponse(true, "", new JwtAuthModel(accessToken, refreshToken));
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during management;\r\nError: [{ex.Message}]");
            return new SignInRefreshResponse(false, GlobalMessageError, null);
        }
    }

    private async Task<RefreshUserResponse> RefreshUserAsync(RefreshUserParams userParams) {
        try {
            if (userParams.User.Equals(null) || userParams.User.Id.Equals(Guid.Empty)) return new RefreshUserResponse(false, "Set current user failed. User was not provided.", RoleType.Unknown, null);

            await _userService.SetLastLoginDateAsync(userParams.User.Id);

            var accessToken = _authJwtHelper.GenerateJwt(userParams.User.Id, userParams.Email, userParams.User.RoleType);
            var refreshToken = _authRefreshJwtHelper.GenerateJwt(userParams.User.Id, userParams.Email, userParams.User.RoleType);

            return new RefreshUserResponse(true, "", userParams.User.RoleType, new JwtAuthModel(accessToken, refreshToken));
        } catch (Exception ex) {
            _loggger.LogError($"An error occurred during management;\r\nError: [{ex.Message}]");
            return new RefreshUserResponse(false, GlobalMessageError, RoleType.Unknown, null);
        }
    }
}