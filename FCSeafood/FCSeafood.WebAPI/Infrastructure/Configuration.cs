using FCSeafood.BLL.User.Auth.Settings;

namespace FCSeafood.WebAPI.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection serviceCollection) {
        serviceCollection.AddTransient<CookieHelper>();

        serviceCollection.AddSingleton<JWTAuthSettings>();
        serviceCollection.AddScoped<IJWTSettings, JWTAuthSettings>();

        serviceCollection.AddTransient<JWTAuthCookieService>();

        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}