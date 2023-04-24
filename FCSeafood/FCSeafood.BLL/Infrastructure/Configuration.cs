using FCSeafood.DAL.Auxiliary.Repository;
using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Repository;
using FCSeafood.DAL.Common.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.BLL.Infrastructure;

public static class Configuration {
    public static void ConfigurationService(IServiceCollection serviceCollection, string connectionString) {
#region Context

        serviceCollection.AddDbContext<EventFCSeafoodContext>(options => options.UseSqlServer(connectionString));
        serviceCollection.AddDbContext<CommonFCSeafoodContext>(options => options.UseSqlServer(connectionString));
        serviceCollection.AddDbContext<AuxiliaryFCSeafoodContext>(options => options.UseSqlServer(connectionString));

#endregion

#region BLL

        // Managers
        serviceCollection.AddTransient<AuthManager>();
        serviceCollection.AddTransient<UserManager>();
        serviceCollection.AddTransient<CommonManager>();

        // Services
        serviceCollection.AddTransient<UserService>();

        // Helpers
        serviceCollection.AddTransient<AuthJwtHelper>();
        serviceCollection.AddTransient<AuthRefreshJwtHelper>();
        serviceCollection.AddTransient<UserMapperHelper>();
        serviceCollection.AddTransient<CommonMapperHelper>();

#endregion

#region DAL

        // Repositories
        serviceCollection.AddTransient<AddressRepository>();
        serviceCollection.AddTransient<UserRepository>();
        serviceCollection.AddTransient<UserCredentialRepository>();
        serviceCollection.AddTransient<ItemRepository>();
        serviceCollection.AddTransient<CategoryTypeRepository>();
        serviceCollection.AddTransient<SubCategoryTypeRepository>();
        serviceCollection.AddTransient<BindCategoryRepository>();

#endregion
    }
}