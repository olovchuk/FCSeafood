using System.Text.Json;
using FCSeafood.BLL.Common;
using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BLL.Services;
using FCSeafood.BusinessObjects;
using FCSeafood.DAL.Common.Repository;
using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.Test;

public class Tests {
    private const string ConnectionString =
        "Data Source=localhost;Initial Catalog=Test;User ID=FCS_User;Password=s1c@r8;TrustServerCertificate=True";

    // Event Repository
    private AddressRepository _addressRepository = null!;
    private ItemRepository _itemRepository = null!;
    private UserCredentialRepository _userCredentialRepository = null!;
    private OrderEntityRepository _orderEntityRepository = null!;
    private OrderRepository _orderRepository = null!;
    private UserRepository _userRepository = null!;

    // Common Repository
    private CategoryTRepository _categoryTRepository = null!;
    private CurrencyCodeTRepository _currencyCodeTRepository = null!;
    private GenderTRepository _genderTRepository = null!;
    private ItemStatusTRepository _itemStatusTRepository = null!;
    private RoleTRepository _roleTRepository = null!;
    private SubcategoryTRepository _subcategoryTRepository = null!;
    private TemperatureUnitTRepository _temperatureUnitTRepository = null!;

    // Service
    private CommonService _commonService = null!;
    private ItemService _itemService = null!;

    // Manger
    private CommonManager _commonManager = null!;
    private ItemManager _itemManager = null!;

    [SetUp]
    public void Setup() {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<EventFCSeafoodContext>(options => options.UseSqlServer(ConnectionString));
        serviceCollection.AddDbContext<CommonFCSeafoodContext>(options => options.UseSqlServer(ConnectionString));

        // Services
        serviceCollection.AddTransient<AddressService>();
        serviceCollection.AddTransient<CommonService>();
        serviceCollection.AddTransient<ItemService>();
        serviceCollection.AddTransient<OrderService>();
        serviceCollection.AddTransient<UserService>();

        // Managers
        serviceCollection.AddTransient<CommonManager>();
        serviceCollection.AddTransient<ItemManager>();


        // Repositories
        // -- Common
        serviceCollection.AddTransient<CategoryTRepository>();
        serviceCollection.AddTransient<CurrencyCodeTRepository>();
        serviceCollection.AddTransient<GenderTRepository>();
        serviceCollection.AddTransient<ItemStatusTRepository>();
        serviceCollection.AddTransient<RoleTRepository>();
        serviceCollection.AddTransient<SubcategoryTRepository>();
        serviceCollection.AddTransient<TemperatureUnitTRepository>();

        // -- Event
        serviceCollection.AddTransient<AddressRepository>();
        serviceCollection.AddTransient<ItemRepository>();
        serviceCollection.AddTransient<UserCredentialRepository>();
        serviceCollection.AddTransient<OrderEntityRepository>();
        serviceCollection.AddTransient<OrderRepository>();
        serviceCollection.AddTransient<UserRepository>();
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Event Repository
        _addressRepository = serviceProvider.GetService<AddressRepository>()!;
        _itemRepository = serviceProvider.GetService<ItemRepository>()!;
        _userCredentialRepository = serviceProvider.GetService<UserCredentialRepository>()!;
        _orderEntityRepository = serviceProvider.GetService<OrderEntityRepository>()!;
        _orderRepository = serviceProvider.GetService<OrderRepository>()!;
        _userRepository = serviceProvider.GetService<UserRepository>()!;

        // Common Repository
        _categoryTRepository = serviceProvider.GetService<CategoryTRepository>()!;
        _currencyCodeTRepository = serviceProvider.GetService<CurrencyCodeTRepository>()!;
        _itemStatusTRepository = serviceProvider.GetService<ItemStatusTRepository>()!;
        _genderTRepository = serviceProvider.GetService<GenderTRepository>()!;
        _roleTRepository = serviceProvider.GetService<RoleTRepository>()!;
        _subcategoryTRepository = serviceProvider.GetService<SubcategoryTRepository>()!;
        _temperatureUnitTRepository = serviceProvider.GetService<TemperatureUnitTRepository>()!;

        // Service
        _commonService = serviceProvider.GetService<CommonService>()!;
        _itemService = serviceProvider.GetService<ItemService>()!;

        // Manager
        _commonManager = serviceProvider.GetService<CommonManager>()!;
        _itemManager = serviceProvider.GetService<ItemManager>()!;
    }

    [Test]
    public async Task GetOrder() {
        var (isSuccessful, models) = await _orderRepository.GetAllAsync();
        Assert.That(isSuccessful, Is.Not.False);

        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(models, options);
        Console.WriteLine(json);
    }

    [Test]
    public async Task GetOrderEntity() {
        var (isSuccessful, models) = await _orderEntityRepository.GetAllAsync();
        Assert.That(isSuccessful, Is.Not.False);

        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(models, options);
        Console.WriteLine(json);
    }

    [Test]
    public async Task GetItemModel() {
        Assert.Multiple(() => { Assert.That(_itemManager, Is.Not.Null); });

        var (isSuccessful, model) = await _itemRepository.FindByConditionAsync(x => x.Name == "Bread");
        Assert.That(model, Is.Not.Null);

        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(model, options);
        Console.WriteLine(json);
    }

    [Test]
    public async Task GetItemModelSort() {
        Assert.Multiple(() => { Assert.That(_itemManager, Is.Not.Null); });

        var itemListModel = await _itemManager.GetItemListAsync(
            new ItemFilterParams(
                CategoryType.Fish
              , SubcategoryType.SeaFish
              , SortDirectionType.NoSort
              , 1
              , 100
            )
        );

        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(itemListModel.ItemModels, options);
        Console.WriteLine(json);
    }

    [Test]
    public async Task GetCategoryTList() {
        Assert.Multiple(
            () => {
                Assert.That(_categoryTRepository, Is.Not.Null);
                Assert.That(_commonService, Is.Not.Null);
                Assert.That(_commonManager, Is.Not.Null);
            }
        );

        var categoryTListResponse = await _commonManager.GetCategoryTListAsync();

        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(categoryTListResponse, options);
        Console.WriteLine(json);
    }

    [Test]
    public async Task TestCommonMappingToModel() {
        var options = new JsonSerializerOptions {
            WriteIndented = true
        };

        var dbo = await _categoryTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo is null) {
            Console.WriteLine(typeof(CategoryTRepository) + " NULL");
            Assert.That(dbo, Is.Not.Null);
            return;
        }

        var model = CategoryTRepository.ToModel(dbo);
        Assert.That(model.success, Is.Not.False);
        var json = JsonSerializer.Serialize(model.model, options);
        Console.WriteLine(typeof(CategoryTRepository) + json + "\n");

        var dbo2 = await _currencyCodeTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo2 is null) {
            Console.WriteLine(typeof(CurrencyCodeTRepository) + " NULL");
            Assert.That(dbo2, Is.Not.Null);
            return;
        }

        var model2 = CurrencyCodeTRepository.ToModel(dbo2);
        Assert.That(model2.success, Is.Not.False);
        json = JsonSerializer.Serialize(model2.model, options);
        Console.WriteLine(typeof(CurrencyCodeTRepository) + json + "\n");

        var dbo3 = await _genderTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo3 is null) {
            Console.WriteLine(typeof(GenderTRepository) + " NULL");
            Assert.That(dbo3, Is.Not.Null);
            return;
        }

        var model3 = GenderTRepository.ToModel(dbo3);
        Assert.That(model3.success, Is.Not.False);
        json = JsonSerializer.Serialize(model3.model, options);
        Console.WriteLine(typeof(GenderTRepository) + json + "\n");

        var dbo4 = await _itemStatusTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo4 is null) {
            Console.WriteLine(typeof(ItemStatusTRepository) + " NULL");
            Assert.That(dbo4, Is.Not.Null);
            return;
        }

        var model4 = ItemStatusTRepository.ToModel(dbo4);
        Assert.That(model4.success, Is.Not.False);
        json = JsonSerializer.Serialize(model4.model, options);
        Console.WriteLine(typeof(ItemStatusTRepository) + json + "\n");

        var dbo5 = await _roleTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo5 is null) {
            Console.WriteLine(typeof(RoleTRepository) + " NULL");
            Assert.That(dbo5, Is.Not.Null);
            return;
        }

        var model5 = RoleTRepository.ToModel(dbo5);
        Assert.That(model5.success, Is.Not.False);
        json = JsonSerializer.Serialize(model5.model, options);
        Console.WriteLine(typeof(RoleTRepository) + json + "\n");

        var dbo6 = await _subcategoryTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo6 is null) {
            Console.WriteLine(typeof(SubcategoryTRepository) + " NULL");
            Assert.That(dbo6, Is.Not.Null);
            return;
        }

        var model6 = SubcategoryTRepository.ToModel(dbo6);
        Assert.That(model6.success, Is.Not.False);
        json = JsonSerializer.Serialize(model6.model, options);
        Console.WriteLine(typeof(SubcategoryTRepository) + json + "\n");

        var dbo7 = await _temperatureUnitTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo7 is null) {
            Console.WriteLine(typeof(TemperatureUnitTRepository) + " NULL");
            Assert.That(dbo7, Is.Not.Null);
            return;
        }

        var model7 = TemperatureUnitTRepository.ToModel(dbo7);
        Assert.That(model7.success, Is.Not.False);
        json = JsonSerializer.Serialize(model7.model, options);
        Console.WriteLine(typeof(TemperatureUnitTRepository) + json + "\n");
    }

    [Test]
    public async Task TestEventMappingToModel() {
        var options = new JsonSerializerOptions {
            WriteIndented = true
        };

        var (isSuccessful, model) = await _addressRepository.FindByConditionAsync(x => x.ZipCode == "432853147");
        if (!isSuccessful) {
            Console.WriteLine(typeof(AddressRepository) + " NULL");
            Assert.That(model, Is.Not.Null);
            return;
        }

        var json = JsonSerializer.Serialize(model, options);
        Console.WriteLine(typeof(AddressRepository) + json + "\n");

        (isSuccessful, var model1) = await _itemRepository.FindByConditionAsync(x => x.Name == "Bread");
        if (!isSuccessful) {
            Console.WriteLine(typeof(ItemRepository) + " NULL");
            Assert.That(model1, Is.Not.Null);
            return;
        }

        json = JsonSerializer.Serialize(model1, options);
        Console.WriteLine(typeof(ItemRepository) + json + "\n");

        (isSuccessful, var model2) =
            await _userCredentialRepository.FindByConditionAsync(x => x.Email == "tom_rider@fcsfood.com");
        if (!isSuccessful) {
            Console.WriteLine(typeof(UserCredentialRepository) + " NULL");
            Assert.That(model2, Is.Not.Null);
            return;
        }

        json = JsonSerializer.Serialize(model2, options);
        Console.WriteLine(typeof(UserCredentialRepository) + json + "\n");

        (isSuccessful, var model3) = await _userRepository.FindByConditionAsync(x => x.FirstName == "Tom");
        if (!isSuccessful) {
            Console.WriteLine(typeof(UserRepository) + " NULL");
            Assert.That(model3, Is.Not.Null);
            return;
        }

        json = JsonSerializer.Serialize(model3, options);
        Console.WriteLine(typeof(UserRepository) + json + "\n");
    }
}