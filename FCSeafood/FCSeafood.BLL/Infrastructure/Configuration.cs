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
        serviceCollection.AddTransient<ItemManager>();

        // Services
        serviceCollection.AddTransient<AddressService>();
        serviceCollection.AddTransient<UserService>();
        serviceCollection.AddTransient<CommonService>();
        serviceCollection.AddTransient<ItemService>();
        serviceCollection.AddTransient<PriceService>();

        // Helpers
        serviceCollection.AddTransient<AuthJwtHelper>();
        serviceCollection.AddTransient<AuthRefreshJwtHelper>();
        serviceCollection.AddTransient<AddressMapperHelper>();
        serviceCollection.AddTransient<UserMapperHelper>();
        serviceCollection.AddTransient<CommonMapperHelper>();
        serviceCollection.AddTransient<ItemMapperHelper>();
        serviceCollection.AddTransient<PriceMapperHelper>();

#endregion

#region DAL

        // Repositories
        serviceCollection.AddTransient<AddressRepository>();
        serviceCollection.AddTransient<UserRepository>();
        serviceCollection.AddTransient<UserCredentialRepository>();
        serviceCollection.AddTransient<ItemRepository>();
        serviceCollection.AddTransient<PriceRepository>();
        serviceCollection.AddTransient<CategoryTRepository>();
        serviceCollection.AddTransient<SubcategoryTRepository>();
        serviceCollection.AddTransient<BindCategoryRepository>();

#endregion
    }
}