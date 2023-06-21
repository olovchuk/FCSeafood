using FCSeafood.BLL.User.Auth.Settings;

namespace FCSeafood.WebAPI.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection serviceCollection) {
        serviceCollection.AddTransient<CookieHelper>();

        serviceCollection.AddSingleton<JwtAuthSettings>();
        serviceCollection.AddScoped<IJWTSettings, JwtAuthSettings>();

        serviceCollection.AddTransient<JwtAuthCookieService>();

        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}