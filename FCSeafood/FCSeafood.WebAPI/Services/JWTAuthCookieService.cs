using FCSeafood.BLL.User.Auth;
using FCSeafood.BLL.User.Auth.Models.Params;
using FCSeafood.BLL.User.Auth.Models.Response;

namespace FCSeafood.WebAPI.Services;

public class JWTAuthCookieService {
    private readonly AuthManager _authManager;
    private readonly CookieHelper _cookieHelper;
    private readonly JWTAuthSettings _jwtAuthSettings;
    public readonly IConfiguration _configuration;

    public JWTAuthCookieService(AuthManager authManager, CookieHelper cookieHelper, JWTAuthSettings jwtAuthSettings, IConfiguration configuration) {
        _authManager = authManager;
        _cookieHelper = cookieHelper;
        _jwtAuthSettings = jwtAuthSettings;
        _configuration = configuration;
    }

    public async Task<SignInResponse> SignInAsync(SignInParams signInParams) {
        var result = await _authManager.SignInAsync(signInParams);

        if (!result.IsSuccessful) return result;

        _cookieHelper.SetCookie(_configuration.GetValue<string>("TokenKeys:Access"), result.JWTAuthModel.AccessToken, TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime), false);
        _cookieHelper.SetCookie(_configuration.GetValue<string>("TokenKeys:Refresh"), result.JWTAuthModel.RefreshToken, TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime), false);
        return result;
    }

    public async Task<SignInRefreshResponse> SignInRefreshAsync(SignInRefreshParams signInRefreshParams) {
        var result = await _authManager.SignInRefreshAsync(signInRefreshParams);

        if (!result.IsSuccessful) return result;

        _cookieHelper.SetCookie(_configuration.GetValue<string>("TokenKeys:Access"), result.JWTAuthModel.AccessToken, TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime), false);
        _cookieHelper.SetCookie(_configuration.GetValue<string>("TokenKeys:Refresh"), result.JWTAuthModel.RefreshToken, TimeSpan.FromSeconds(_jwtAuthSettings.TokenLifeTime), false);
        return result;
    }

    public SignOutResponse SignOut(SignOutParams signOutParams) {
        _cookieHelper.RemoveCookie(_configuration.GetValue<string>("TokenKeys:Access"));
        _cookieHelper.RemoveCookie(_configuration.GetValue<string>("TokenKeys:Refresh"));

        return new SignOutResponse(true, "");
    }
}