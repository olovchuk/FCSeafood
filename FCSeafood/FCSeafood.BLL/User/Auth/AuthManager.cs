using System.IdentityModel.Tokens.Jwt;
using FCSeafood.DAL.Events;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.User.Auth;

public class AuthManager {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(UserRepository));

    // TODO: Set support email from global settings
    private const string GLOBAL_MESSAGE_ERROR = "Authentication failed. Please please try to sign in again or contact us via [Email]";

    private readonly UserRepository _userRepository;
    private readonly UserCredentialRepository _userCredentialRepository;
    private readonly AuthJWTHelper _authJwtHelper;
    private readonly AuthRefreshJWTHelper _authRefreshJwtHelper;

    public AuthManager(UserRepository userRepository, UserCredentialRepository userCredentialRepository, AuthJWTHelper authJwtHelper, AuthRefreshJWTHelper authRefreshJwtHelper) {
        _userRepository = userRepository;
        _userCredentialRepository = userCredentialRepository;
        _authJwtHelper = authJwtHelper;
        _authRefreshJwtHelper = authRefreshJwtHelper;
    }

    public async Task<SignInResponse> SignInAsync(SignInParams singInParams) {
        var errorResponse = new SignInResponse(false, "Email or Password incorrect. Please try again.", 0, null);
        try {
            var userCredential = await _userCredentialRepository.GetByEmailAsync(singInParams.Email);
            if (userCredential is null) return errorResponse;

            var user = await _userRepository.GetByIdAsync(userCredential.Id);
            if (user is null) return errorResponse;

            var valid = await _userCredentialRepository.IsExistsAsync(userCredential.Id, singInParams.Email, singInParams.Password);
            if (!valid) return errorResponse;

            var refreshUserResult = await RefreshUserAsync(new RefreshUserParams(user, userCredential.Email));
            if (!refreshUserResult.IsSuccessful) return new SignInResponse(false, refreshUserResult.Message, 0, null);

            var jwtAuthModel = new JWTAuthModel(refreshUserResult.JWTAuthModel?.AccessToken!, refreshUserResult.JWTAuthModel?.RefreshToken!);
            return new SignInResponse(true, "", refreshUserResult.RoleType, jwtAuthModel);
        } catch (Exception ex) {
            log.LogError($"Failed to sign in;\r\nEmail: [{singInParams.Email}]\r\nError: [{ex.Message}]");
            return new SignInResponse(false, ex.Message, 0, null);
        }
    }

    public async Task<SignInRefreshResponse> SignInRefreshAsync(SignInRefreshParams signInRefreshParams) {
        var errorResponse = new SignInRefreshResponse(false, GLOBAL_MESSAGE_ERROR, null);
        try {
            var token = _authJwtHelper.Validate(signInRefreshParams.RefreshToken);
            if (token is null) return errorResponse;

            var claimsValues = JWTClaimsHelper.GetUserClaims(token.Claims);
            if (!claimsValues.IsValid) return errorResponse;

            var user = await _userRepository.GetByIdAsync(claimsValues.UserId);
            if (user is null) return errorResponse;

            var credential = await _userCredentialRepository.GetByUserIdAsync(user.Id);
            if (credential is null) return errorResponse;

            var accessToken = _authJwtHelper.GenerateJWT(user.Id, credential.Email, user.RoleType);
            var refreshToken = _authRefreshJwtHelper.GenerateJWT(user.Id, credential.Email, user.RoleType);

            return new SignInRefreshResponse(true, "", new JWTAuthModel(accessToken, refreshToken));
        } catch (Exception ex) {
            log.LogError($"Failed to sign in refresh;\r\nError: [{ex.Message}]");
            return new SignInRefreshResponse(false, GLOBAL_MESSAGE_ERROR, null);
        }
    }

    private async Task<RefreshUserResponse> RefreshUserAsync(RefreshUserParams userParams) {
        try {
            if (userParams.User.Equals(null) || userParams.User.Id.Equals(Guid.Empty)) return new RefreshUserResponse(false, "Set current user failed. User was not provided.", 0, null);

            await _userCredentialRepository.SetLastLoginDateAsync(userParams.User.Id);

            var accessToken = _authJwtHelper.GenerateJWT(userParams.User.Id, userParams.Email, userParams.User.RoleType);
            var refreshToken = _authRefreshJwtHelper.GenerateJWT(userParams.User.Id, userParams.Email, userParams.User.RoleType);

            return new RefreshUserResponse(true, "", userParams.User.RoleType, new JWTAuthModel(accessToken, refreshToken));
        } catch (Exception ex) {
            log.LogError($"Failed to refresh user;\r\nError: [{ex.Message}]");
            return new RefreshUserResponse(false, GLOBAL_MESSAGE_ERROR, 0, null);
        }
    }
}