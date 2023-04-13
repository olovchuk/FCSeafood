using FCSeafood.BLL.User.Auth.Settings;

namespace FCSeafood.WebAPI.Settings;

public class JWTAuthSettings : IJWTSettings {
    public readonly IConfiguration _configuration;

    public JWTAuthSettings(IConfiguration configuration) {
        _configuration = configuration;
    }

    private string _issuer;

    public string Issuer {
        get {
            if (string.IsNullOrWhiteSpace(_issuer)) _issuer = _configuration.GetValue<string>("JWTAuthSetting:AuthIssuer");
            return _issuer ?? "";
        }
    }

    private string _audience;

    public string Audience {
        get {
            if (string.IsNullOrWhiteSpace(_audience)) _audience = _configuration.GetValue<string>("JWTAuthSetting:AuthAudience");
            return _audience ?? "";
        }
    }

    private string _secret;

    public string Secret {
        get {
            if (string.IsNullOrWhiteSpace(_secret)) _secret = _configuration.GetValue<string>("JWTAuthSetting:AuthSecret");
            return _secret ?? "";
        }
    }

    private int? _tokenLifeTime;

    public int TokenLifeTime {
        get {
            _tokenLifeTime ??= _configuration.GetValue<int>("JWTAuthSetting:AuthTokenLifeTime");
            return _tokenLifeTime ?? 0;
        }
    }
}