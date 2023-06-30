using FCSeafood.BLL.Settings;

namespace FCSeafood.BLL.User.Auth;

public class AuthManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(AuthManager));

    private readonly UserService _userService;
    private readonly AuthJwtHelper _authJwtHelper;
    private readonly AuthRefreshJwtHelper _authRefreshJwtHelper;
    private readonly EmailService _emailService;
    private readonly GlobalSettings _globalSettings;

    public AuthManager(
        UserService userService
      , AuthJwtHelper authJwtHelper
      , AuthRefreshJwtHelper authRefreshJwtHelper
      , EmailService emailService
      , GlobalSettings globalSettings
    ) {
        _userService = userService;
        _authJwtHelper = authJwtHelper;
        _authRefreshJwtHelper = authRefreshJwtHelper;
        _emailService = emailService;
        _globalSettings = globalSettings;
    }

    public async Task<SignInResponse> SignInAsync(SignInParams singInParams) {
        var errorResponse = new SignInResponse(
            false
          , ErrorMessage.Authentication.EmailOrPasswordIncorrect
          , RoleType.Unknown
          , null
        );
        try {
            var userCredential = await _userService.GetCredentialByEmailAsync(singInParams.Email);
            if (userCredential is null)
                return errorResponse;

            if (HashHelper.HashSha256(singInParams.Password) != userCredential.Password)
                return errorResponse;

            var user = await _userService.GetUserAsync(userCredential.Id);
            if (user is null)
                return errorResponse;

            var refreshUserResult = await RefreshUserAsync(new RefreshUserParams(user, userCredential.Email));
            if (!refreshUserResult.IsSuccessful)
                return new SignInResponse(
                    false
                  , refreshUserResult.Message
                  , RoleType.Unknown
                  , null
                );

            var jwtAuthModel = new JwtAuthModel(
                refreshUserResult.JwtAuthModel?.AccessToken!
              , refreshUserResult.JwtAuthModel?.RefreshToken!
            );
            return new SignInResponse(
                true
              , ""
              , refreshUserResult.RoleType
              , jwtAuthModel
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new SignInResponse(
                false
              , ErrorMessage.Authentication.AuthenticationFailed
              , RoleType.Unknown
              , null
            );
        }
    }

    public async Task<SignInResponse> SignInGuestAsync() {
        var errorResponse = new SignInResponse(
            false
          , ErrorMessage.Authentication.AuthenticationGuestFailed
          , RoleType.Unknown
          , null
        );
        try {
            var userGuestModel = await _userService.InsertGuestAsync();
            if (userGuestModel is null)
                return errorResponse;

            var refreshGuestResult = RefreshGuest(new RefreshGuestParams(userGuestModel));
            if (!refreshGuestResult.IsSuccessful)
                return new SignInResponse(
                    false
                  , refreshGuestResult.Message
                  , RoleType.Unknown
                  , null
                );

            var jwtAuthModel = new JwtAuthModel(
                refreshGuestResult.JwtAuthModel?.AccessToken!
              , refreshGuestResult.JwtAuthModel?.RefreshToken!
            );
            return new SignInResponse(
                true
              , ""
              , refreshGuestResult.RoleType
              , jwtAuthModel
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new SignInResponse(
                false
              , ErrorMessage.Authentication.AuthenticationGuestFailed
              , RoleType.Unknown
              , null
            );
        }
    }

    public async Task<SignInRefreshResponse> SignInRefreshAsync(SignInRefreshParams signInRefreshParams) {
        var errorResponse = new SignInRefreshResponse(false, ErrorMessage.Authentication.AuthenticationFailed, null);
        try {
            var token = _authJwtHelper.Validate(signInRefreshParams.RefreshToken);
            if (token is null)
                return errorResponse;

            var claimsValues = JwtClaimsHelper.GetUserClaims(token.Claims);
            if (!claimsValues.IsValid)
                return errorResponse;

            var user = await _userService.GetUserAsync(claimsValues.UserId);
            if (user is null)
                return errorResponse;

            var credential = await _userService.GetCredentialByUserIdAsync(user.Id);
            if (credential is null)
                return errorResponse;

            var accessToken = _authJwtHelper.GenerateJwt(user.Id, credential.Email, user.Role.Type);
            var refreshToken = _authRefreshJwtHelper.GenerateJwt(user.Id, credential.Email, user.Role.Type);

            return new SignInRefreshResponse(true, "", new JwtAuthModel(accessToken, refreshToken));
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new SignInRefreshResponse(false, ErrorMessage.Authentication.AuthenticationFailed, null);
        }
    }

    public async Task<SignUpResponse> SignUpAsync(SignUpParams signUpParams) {
        try {
            var signUpResponse = _userService.IsValidateCredentialForSignUp(signUpParams);
            if (!signUpResponse.IsSuccessful)
                return signUpResponse;

            var userModel = new UserModel {
                FirstName = signUpParams.FirstName
              , LastName = signUpParams.LastName
            };
            userModel = await _userService.InsertUserAsync(userModel);
            if (userModel is null)
                return new SignUpResponse(false, ErrorMessage.Authentication.InsertUserFailed);

            var credentialModel = new UserCredentialModel {
                Id = userModel.Id
              , Email = signUpParams.Email
              , Password = HashHelper.HashSha256(signUpParams.Password)
            };
            credentialModel = await _userService.InsertCredentialAsync(credentialModel);
            if (credentialModel is null)
                return new SignUpResponse(false, ErrorMessage.Authentication.InsertCredentialFailed);

            return new SignUpResponse(true, "");
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new SignUpResponse(false, ErrorMessage.Authentication.SignUpFailed);
        }
    }

    private async Task<RefreshUserResponse> RefreshUserAsync(RefreshUserParams userParams) {
        try {
            if (userParams.User.Equals(null) || userParams.User.Id.Equals(Guid.Empty))
                return new RefreshUserResponse(
                    false
                  , ErrorMessage.User.IsNotDefined
                  , RoleType.Unknown
                  , null
                );

            await _userService.SetLastLoginDateAsync(userParams.User.Id);

            var accessToken = _authJwtHelper.GenerateJwt(
                userParams.User.Id
              , userParams.Email
              , userParams.User.Role.Type
            );
            var refreshToken = _authRefreshJwtHelper.GenerateJwt(
                userParams.User.Id
              , userParams.Email
              , userParams.User.Role.Type
            );

            return new RefreshUserResponse(
                true
              , ""
              , userParams.User.Role.Type
              , new JwtAuthModel(accessToken, refreshToken)
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new RefreshUserResponse(
                false
              , ErrorMessage.Authentication.AuthenticationFailed
              , RoleType.Unknown
              , null
            );
        }
    }

    private RefreshGuestResponse RefreshGuest(RefreshGuestParams guestParams) {
        try {
            if (guestParams.User.Equals(null) || guestParams.User.Id.Equals(Guid.Empty))
                return new RefreshGuestResponse(
                    false
                  , ErrorMessage.User.IsNotDefined
                  , RoleType.Unknown
                  , null
                );

            var accessToken = _authJwtHelper.GenerateJwt(
                guestParams.User.Id
              , string.Empty
              , guestParams.User.Role.Type
            );

            return new RefreshGuestResponse(
                true
              , ""
              , guestParams.User.Role.Type
              , new JwtAuthModel(accessToken, string.Empty)
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new RefreshGuestResponse(
                false
              , ErrorMessage.Authentication.AuthenticationGuestFailed
              , RoleType.Unknown
              , null
            );
        }
    }

    public async Task<EmptyResponse> ResetPasswordAsync(Guid userId) {
        try {
            var userModel = await _userService.GetUserAsync(userId);
            if (userModel is null)
                return new EmptyResponse(false, ErrorMessage.User.IsNotDefined);

            if (await _userService.IsUserHaveCodesForResetPasswordAsync(userId)) {
                await _userService.RemoveAllCodesForResetPasswordAsync(userId);
            }

            var code = await _userService.GetCodeForResetPassword(userId);
            if (code <= 0)
                return new EmptyResponse(false, ErrorMessage.User.IsNotDefined);

            var confirmUrl = $"{_globalSettings.DomainUrl}/account/reset-password?cd={code}";
            await _emailService.SendEmailResetPassword(userModel.Email, userModel.GetFullName, confirmUrl);
            return new EmptyResponse(true, string.Empty);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new EmptyResponse(false, ErrorMessage.Email.Error);
        }
    }

    public async Task<EmptyResponse> IsExistsResetPasswordCodeAsync(Guid userId, int code) {
        try {
            var resetPasswordLModel = await _userService.GetResetPassword(userId, code);
            if (resetPasswordLModel is null)
                return new EmptyResponse(false, ErrorMessage.Authentication.ChangePasswordNotAllowed);

            if (resetPasswordLModel.ExpirationDate <= DateTime.Now)
                return new EmptyResponse(false, ErrorMessage.Authentication.PasswordResetExpired);

            return new EmptyResponse(true, "");
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new EmptyResponse(false, ErrorMessage.Email.Error);
        }
    }

    public async Task<EmptyResponse> ForgotPasswordAsync(ForgotPasswordParams forgotPasswordParams) {
        try {
            var userModel = await _userService.GetUserByEmailAsync(forgotPasswordParams.UserEmail);
            if (userModel is null)
                return new EmptyResponse(false, ErrorMessage.User.IsNotDefined);

            var userNewPassword = GeneratePassword(10);
            await _userService.UpdateUserPassword(userModel.Id, HashHelper.HashSha256(userNewPassword));

            _emailService.SendEmailForgotPassword(userModel.Email, userModel.GetFullName, userNewPassword);
            return new EmptyResponse(true, string.Empty);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new EmptyResponse(false, ErrorMessage.Email.Error);
        }
    }

    private string GeneratePassword(int length) {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var result = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        return result;
    }
}