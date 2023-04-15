using FCSeafood.BLL.User.Info;
using FCSeafood.BLL.User.Info.Helpers;
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
        serviceCollection.AddTransient<UserManager>();
        serviceCollection.AddTransient<UserMapperHelper>();

        // DAL
        serviceCollection.AddTransient<AddressRepository>();
        serviceCollection.AddTransient<UserRepository>();
        serviceCollection.AddTransient<UserCredentialRepository>();
        serviceCollection.AddTransient<ItemRepository>();
    }
}