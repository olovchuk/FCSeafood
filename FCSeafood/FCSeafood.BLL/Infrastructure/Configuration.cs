using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.BLL.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString) {
        serviceCollection.AddDbContext<EventFCSeafoodContext>(options => options.UseSqlServer(connectionString));

        // BLL
        serviceCollection.AddTransient<AuthManager>();
        serviceCollection.AddTransient<AuthJWTHelper>();
        serviceCollection.AddTransient<AuthRefreshJWTHelper>();

        // DAL
        serviceCollection.AddTransient<UserRepository>();
        serviceCollection.AddTransient<UserCredentialRepository>();
    }
}