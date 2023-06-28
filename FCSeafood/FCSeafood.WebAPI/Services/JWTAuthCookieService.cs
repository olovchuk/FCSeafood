using FCSeafood.BLL.http.Response;
using FCSeafood.BLL.User.Auth;
using FCSeafood.BLL.User.Auth.Models.Params;
using FCSeafood.BLL.User.Auth.Models.Response;

namespace FCSeafood.WebAPI.Services;

public class JwtAuthCookieService {
    private readonly AuthManager _authManager;
    private readonly CookieHelper _cookieHelper;
    private readonly JwtAuthSettings _jwtAuthSettings;
    public readonly IConfiguration Configuration;

    public JwtAuthCookieService(
        AuthManager authManager
      , CookieHelper cookieHelper
      , JwtAuthSettings jwtAuthSettings
      , IConfiguration configuration
    ) {
        _authManager = authManager;
        _cookieHelper = cookieHelper;
        _jwtAuthSettings = jwtAuthSettings;
        Configuration = configuration;
    }

    public async Task<SignInResponse> SignInAsync(SignInParams signInParams) {
        var result = await _authManager.SignInAsync(signInParams);

        if (!result.IsSuccessful)
            return result;

        _cookieHelper.SetCookie(
            Configuration.GetValue<string>("TokenKeys:Access")!
          , result.JwtAuthModel!.AccessToken
          , TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime)
          , false
        );
        _cookieHelper.SetCookie(
            Configuration.GetValue<string>("TokenKeys:Refresh")!
          , result.JwtAuthModel.RefreshToken
          , TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime)
          , false
        );
        return result;
    }

    public async Task<SignInResponse> SignInGuestAsync() {
        var result = await _authManager.SignInGuestAsync();
        if (!result.IsSuccessful)
            return result;

        _cookieHelper.SetCookie(
            Configuration.GetValue<string>("TokenKeys:AccessGuest")!
          , result.JwtAuthModel!.AccessToken
          , TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime)
          , false
        );
        return result;
    }

    public async Task<SignInRefreshResponse> SignInRefreshAsync(SignInRefreshParams signInRefreshParams) {
        var result = await _authManager.SignInRefreshAsync(signInRefreshParams);

        if (!result.IsSuccessful)
            return result;

        _cookieHelper.SetCookie(
            Configuration.GetValue<string>("TokenKeys:Access")!
          , result.JwtAuthModel!.AccessToken
          , TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime)
          , false
        );
        _cookieHelper.SetCookie(
            Configuration.GetValue<string>("TokenKeys:Refresh")!
          , result.JwtAuthModel.RefreshToken
          , TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime)
          , false
        );
        return result;
    }

    public async Task<SignUpResponse> SignUpAsync(SignUpParams signUpParams) {
        var result = await _authManager.SignUpAsync(signUpParams);

        return result;
    }

    public SignOutResponse SignOut(SignOutParams signOutParams) {
        _cookieHelper.RemoveCookie(Configuration.GetValue<string>("TokenKeys:Access")!);
        _cookieHelper.RemoveCookie(Configuration.GetValue<string>("TokenKeys:Refresh")!);

        return new SignOutResponse(true, "");
    }

    public async Task<EmptyResponse> ResetPasswordAsync(Guid userId) {
        return await this._authManager.ResetPasswordAsync(userId);
    }

    public async Task<EmptyResponse> IsExistsResetPasswordCodeAsync(Guid userId, int code) {
        return await this._authManager.IsExistsResetPasswordCodeAsync(userId, code);
    }

    public async Task<EmptyResponse> ForgotPasswordAsync(ForgotPasswordParams forgotPasswordParams) {
        return await this._authManager.ForgotPasswordAsync(forgotPasswordParams);
    }
}