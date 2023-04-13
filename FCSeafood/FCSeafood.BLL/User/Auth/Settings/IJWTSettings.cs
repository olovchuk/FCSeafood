namespace FCSeafood.BLL.User.Auth.Settings;

public interface IJWTSettings {
    string Issuer { get; }
    string Audience { get; }
    string Secret { get; }
    int TokenLifeTime { get; }
}