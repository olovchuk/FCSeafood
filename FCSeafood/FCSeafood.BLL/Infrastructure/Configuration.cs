using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Repository;
using FCSeafood.DAL.Common.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.BLL.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString) {
        serviceCollection.AddDbContext<EventFCSeafoodContext>(options => options.UseSqlServer(connectionString));
        serviceCollection.AddDbContext<CommonFCSeafoodContext>(options => options.UseSqlServer(connectionString));

        // BLL
        serviceCollection.AddTransient<AuthManager>();
        serviceCollection.AddTransient<AuthJWTHelper>();
        serviceCollection.AddTransient<AuthRefreshJWTHelper>();
        serviceCollection.AddTransient<UserManager>();
        serviceCollection.AddTransient<UserMapperHelper>();
        serviceCollection.AddTransient<CommonManager>();
        serviceCollection.AddTransient<CommonMapperHelper>();

        // DAL
        serviceCollection.AddTransient<AddressRepository>();
        serviceCollection.AddTransient<UserRepository>();
        serviceCollection.AddTransient<UserCredentialRepository>();
        serviceCollection.AddTransient<ItemRepository>();
        serviceCollection.AddTransient<CategoryTypeRepository>();
    }
}