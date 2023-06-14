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

        #endregion

        #region BLL

        // Services
        serviceCollection.AddTransient<AddressService>();
        serviceCollection.AddTransient<CommonService>();
        serviceCollection.AddTransient<DeliveryService>();
        serviceCollection.AddTransient<ItemService>();
        serviceCollection.AddTransient<OrderService>();
        serviceCollection.AddTransient<UserService>();

        // Managers
        serviceCollection.AddTransient<AuthManager>();
        serviceCollection.AddTransient<CommonManager>();
        serviceCollection.AddTransient<ItemManager>();
        serviceCollection.AddTransient<OrderManager>();
        serviceCollection.AddTransient<UserManager>();

        // Helpers
        serviceCollection.AddTransient<AuthJwtHelper>();
        serviceCollection.AddTransient<AuthRefreshJwtHelper>();

        #endregion

        #region DAL

        // Repositories
        // -- Common
        serviceCollection.AddTransient<CategoryTRepository>();
        serviceCollection.AddTransient<CurrencyCodeTRepository>();
        serviceCollection.AddTransient<DeliveryStatusTRepository>();
        serviceCollection.AddTransient<GenderTRepository>();
        serviceCollection.AddTransient<ItemStatusTRepository>();
        serviceCollection.AddTransient<PaymentMethodTRepository>();
        serviceCollection.AddTransient<RatingTRepository>();
        serviceCollection.AddTransient<RoleTRepository>();
        serviceCollection.AddTransient<SubcategoryTRepository>();
        serviceCollection.AddTransient<TemperatureUnitTRepository>();

        // -- Event
        serviceCollection.AddTransient<AddressRepository>();
        serviceCollection.AddTransient<DeliveryRepository>();
        serviceCollection.AddTransient<ItemRepository>();
        serviceCollection.AddTransient<OrderEntityRepository>();
        serviceCollection.AddTransient<OrderRepository>();
        serviceCollection.AddTransient<RatingLRepository>();
        serviceCollection.AddTransient<UserCredentialRepository>();
        serviceCollection.AddTransient<UserRepository>();

        #endregion
    }
}