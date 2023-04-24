using FCSeafood.BLL.User.Auth.Settings;

namespace FCSeafood.WebAPI.Settings;

public class JwtAuthSettings : IJWTSettings {
    public readonly IConfiguration Configuration;

    public JwtAuthSettings(IConfiguration configuration) {
        Configuration = configuration;
    }

    private string? _issuer;

    public string Issuer {
        get {
            if (string.IsNullOrWhiteSpace(_issuer)) _issuer = Configuration.GetValue<string>("JWTAuthSetting:AuthIssuer");
            return _issuer ?? "";
        }
    }

    private string? _audience;

    public string Audience {
        get {
            if (string.IsNullOrWhiteSpace(_audience)) _audience = Configuration.GetValue<string>("JWTAuthSetting:AuthAudience");
            return _audience ?? "";
        }
    }

    private string? _secret;

    public string Secret {
        get {
            if (string.IsNullOrWhiteSpace(_secret)) _secret = Configuration.GetValue<string>("JWTAuthSetting:AuthSecret");
            return _secret ?? "";
        }
    }

    private int? _tokenLifeTime;

    public int TokenLifeTime {
        get {
            _tokenLifeTime ??= Configuration.GetValue<int>("JWTAuthSetting:AuthTokenLifeTime");
            return _tokenLifeTime ?? 0;
        }
    }
}