using System.Text.Json;
using FCSeafood.BLL.Common;
using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Common;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BLL.Services;
using FCSeafood.BusinessObjects;
using FCSeafood.DAL.Common.Repository;
using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Repository;
using Microsoft.EntityFrameworkCore;

namespace FCSeafood.Test;

public class Tests {
    private const string ConnectionString = "Data Source=localhost;Initial Catalog=Test;User ID=FCS_User;Password=s1c@r8;TrustServerCertificate=True";

    // Context
    private CommonFCSeafoodContext _commonFcSeafoodContext = null!;
    private EventFCSeafoodContext _eventFcSeafoodContext = null!;

    // Event Repository
    private AddressRepository _addressRepository = null!;
    private ItemRepository _itemRepository = null!;
    private PriceRepository _priceRepository = null!;
    private UserCredentialRepository _userCredentialRepository = null!;
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
    private PriceService _priceService = null!;

    // Manger
    private CommonManager _commonManager = null!;
    private ItemManager _itemManager = null!;

    [SetUp]
    public void Setup() {
        var dbCommonOptions = new DbContextOptionsBuilder<CommonFCSeafoodContext>();
        var dbEventOptions = new DbContextOptionsBuilder<EventFCSeafoodContext>();
        dbCommonOptions.UseSqlServer(ConnectionString);
        dbEventOptions.UseSqlServer(ConnectionString);

        // Context
        _commonFcSeafoodContext = new CommonFCSeafoodContext(dbCommonOptions.Options);
        _eventFcSeafoodContext = new EventFCSeafoodContext(dbEventOptions.Options);

        // Event Repository
        _addressRepository = new AddressRepository(_eventFcSeafoodContext);
        _itemRepository = new ItemRepository(_eventFcSeafoodContext);
        _priceRepository = new PriceRepository(_eventFcSeafoodContext);
        _userCredentialRepository = new UserCredentialRepository(_eventFcSeafoodContext);
        _userRepository = new UserRepository(_eventFcSeafoodContext);

        // Common Repository
        _categoryTRepository = new CategoryTRepository(_commonFcSeafoodContext);
        _currencyCodeTRepository = new CurrencyCodeTRepository(_commonFcSeafoodContext);
        _itemStatusTRepository = new ItemStatusTRepository(_commonFcSeafoodContext);
        _genderTRepository = new GenderTRepository(_commonFcSeafoodContext);
        _roleTRepository = new RoleTRepository(_commonFcSeafoodContext);
        _subcategoryTRepository = new SubcategoryTRepository(_commonFcSeafoodContext);
        _temperatureUnitTRepository = new TemperatureUnitTRepository(_commonFcSeafoodContext);

        // Service
        _commonService = new CommonService(_categoryTRepository, _subcategoryTRepository);
        _itemService = new ItemService(_itemRepository);
        _priceService = new PriceService(_priceRepository);

        // Manager
        _commonManager = new CommonManager(_commonService);
        _itemManager = new ItemManager(_itemService);
    }

    [Test]
    public async Task GetItemDbo() {
        Assert.Multiple(() => {
            Assert.That(_itemManager, Is.Not.Null);
        });

        var itemDbos = await _itemRepository.FindByConditionAsync(x => x.Name == "Bread");
        Assert.That(itemDbos, Is.Not.Null);

        var oprions = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(itemDbos, oprions);
        Console.WriteLine(json);
    }

    [Test]
    public async Task GetItemModel() {
        Assert.Multiple(() => {
            Assert.That(_itemManager, Is.Not.Null);
        });

        var itemListModel = await _itemManager.GetItemListAsync(new ItemByFilterParams(new ItemFilterModel {
            CategoryType = CategoryType.Fish, SubcategoryType = SubcategoryType.SeaFish
        }));

        var oprions = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(itemListModel.ItemModels, oprions);
        Console.WriteLine(json);
    }

    [Test]
    public async Task GetCategoryTList() {
        Assert.Multiple(() => {
            Assert.That(_categoryTRepository, Is.Not.Null);
            Assert.That(_commonService, Is.Not.Null);
            Assert.That(_commonManager, Is.Not.Null);
        });

        var categoryTListResponse = await _commonManager.GetCategoryTListAsync();

        var oprions = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(categoryTListResponse, oprions);
        Console.WriteLine(json);
    }

    [Test]
    public async Task TestCommonMappingToModel() {
        var oprions = new JsonSerializerOptions {
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
        var json = JsonSerializer.Serialize(model.model, oprions);
        Console.WriteLine(typeof(CategoryTRepository) + json + "\n");

        var dbo2 = await _currencyCodeTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo2 is null) {
            Console.WriteLine(typeof(CurrencyCodeTRepository) + " NULL");
            Assert.That(dbo2, Is.Not.Null);
            return;
        }
        var model2 = CurrencyCodeTRepository.ToModel(dbo2);
        Assert.That(model2.success, Is.Not.False);
        json = JsonSerializer.Serialize(model2.model, oprions);
        Console.WriteLine(typeof(CurrencyCodeTRepository) + json + "\n");

        var dbo3 = await _genderTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo3 is null) {
            Console.WriteLine(typeof(GenderTRepository) + " NULL");
            Assert.That(dbo3, Is.Not.Null);
            return;
        }
        var model3 = GenderTRepository.ToModel(dbo3);
        Assert.That(model3.success, Is.Not.False);
        json = JsonSerializer.Serialize(model3.model, oprions);
        Console.WriteLine(typeof(GenderTRepository) + json + "\n");

        var dbo4 = await _itemStatusTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo4 is null) {
            Console.WriteLine(typeof(ItemStatusTRepository) + " NULL");
            Assert.That(dbo4, Is.Not.Null);
            return;
        }
        var model4 = ItemStatusTRepository.ToModel(dbo4);
        Assert.That(model4.success, Is.Not.False);
        json = JsonSerializer.Serialize(model4.model, oprions);
        Console.WriteLine(typeof(ItemStatusTRepository) + json + "\n");

        var dbo5 = await _roleTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo5 is null) {
            Console.WriteLine(typeof(RoleTRepository) + " NULL");
            Assert.That(dbo5, Is.Not.Null);
            return;
        }
        var model5 = RoleTRepository.ToModel(dbo5);
        Assert.That(model5.success, Is.Not.False);
        json = JsonSerializer.Serialize(model5.model, oprions);
        Console.WriteLine(typeof(RoleTRepository) + json + "\n");

        var dbo6 = await _subcategoryTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo6 is null) {
            Console.WriteLine(typeof(SubcategoryTRepository) + " NULL");
            Assert.That(dbo6, Is.Not.Null);
            return;
        }
        var model6 = SubcategoryTRepository.ToModel(dbo6);
        Assert.That(model6.success, Is.Not.False);
        json = JsonSerializer.Serialize(model6.model, oprions);
        Console.WriteLine(typeof(SubcategoryTRepository) + json + "\n");

        var dbo7 = await _temperatureUnitTRepository.FindByConditionAsync(x => x.Id == 1);
        if (dbo7 is null) {
            Console.WriteLine(typeof(TemperatureUnitTRepository) + " NULL");
            Assert.That(dbo7, Is.Not.Null);
            return;
        }
        var model7 = TemperatureUnitTRepository.ToModel(dbo7);
        Assert.That(model7.success, Is.Not.False);
        json = JsonSerializer.Serialize(model7.model, oprions);
        Console.WriteLine(typeof(TemperatureUnitTRepository) + json + "\n");
    }

    [Test]
    public async Task TestEventMappingToModel() {
        var oprions = new JsonSerializerOptions {
            WriteIndented = true
        };

        var dbo = await _addressRepository.FindByConditionAsync(x => x.ZipCode == "432853147");
        if (dbo is null) {
            Console.WriteLine(typeof(AddressRepository) + " NULL");
            Assert.That(dbo, Is.Not.Null);
            return;
        }
        var model = AddressRepository.ToModel(dbo);
        Assert.That(model.success, Is.Not.False);
        var json = JsonSerializer.Serialize(model.model, oprions);
        Console.WriteLine(typeof(AddressRepository) + json + "\n");

        var dbo2 = await _itemRepository.FindByConditionAsync(x => x.Name == "Bread");
        if (dbo2 is null) {
            Console.WriteLine(typeof(ItemRepository) + " NULL");
            Assert.That(dbo2, Is.Not.Null);
            return;
        }
        var model2 = ItemRepository.ToModel(dbo2);
        Assert.That(model2.success, Is.Not.False);
        json = JsonSerializer.Serialize(model2.model, oprions);
        Console.WriteLine(typeof(ItemRepository) + json + "\n");

        var dbo3 = await _priceRepository.FindByConditionAsync(x => x.Price == 100);
        if (dbo3 is null) {
            Console.WriteLine(typeof(PriceRepository) + " NULL");
            Assert.That(dbo3, Is.Not.Null);
            return;
        }
        var model3 = PriceRepository.ToModel(dbo3);
        Assert.That(model3.success, Is.Not.False);
        json = JsonSerializer.Serialize(model3.model, oprions);
        Console.WriteLine(typeof(PriceRepository) + json + "\n");

        var dbo4 = await _userCredentialRepository.FindByConditionAsync(x => x.Email == "tom_rider@fcsfood.com");
        if (dbo4 is null) {
            Console.WriteLine(typeof(UserCredentialRepository) + " NULL");
            Assert.That(dbo4, Is.Not.Null);
            return;
        }
        var model4 = UserCredentialRepository.ToModel(dbo4);
        Assert.That(model4.success, Is.Not.False);
        json = JsonSerializer.Serialize(model4.model, oprions);
        Console.WriteLine(typeof(UserCredentialRepository) + json + "\n");

        var dbo5 = await _userRepository.FindByConditionAsync(x => x.FirstName == "Tom");
        if (dbo5 is null) {
            Console.WriteLine(typeof(UserRepository) + " NULL");
            Assert.That(dbo5, Is.Not.Null);
            return;
        }
        var model5 = UserRepository.ToModel(dbo5);
        Assert.That(model5.success, Is.Not.False);
        json = JsonSerializer.Serialize(model5.model, oprions);
        Console.WriteLine(typeof(UserRepository) + json + "\n");
    }
}