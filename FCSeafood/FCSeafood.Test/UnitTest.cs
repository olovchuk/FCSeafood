using System.Text.Json;
using FCSeafood.BLL.Common;
using FCSeafood.BLL.Helpers;
using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Common;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BLL.Services;
using FCSeafood.BusinessObjects;
using FCSeafood.BusinessObjects.Models.Events;
using FCSeafood.DAL.Auxiliary.Repository;
using FCSeafood.DAL.Common.Repository;
using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Repository;
using Microsoft.EntityFrameworkCore;

namespace FCSeafood.Test;

public class Tests {
    private const string ConnectionString = "Data Source=localhost;Initial Catalog=Test;User ID=FCS_User;Password=s1c@r8;TrustServerCertificate=True";
    private EventFCSeafoodContext _eventFcSeafoodContext = null!;
    private CommonFCSeafoodContext _commonFcSeafoodContext = null!;
    private AuxiliaryFCSeafoodContext _auxiliaryFcSeafoodContext = null!;

    // Item
    private ItemRepository _itemRepository = null!;
    private ItemService _itemService = null!;
    private ItemMapperHelper _itemMapperHelper = null!;
    private ItemManager _itemManager = null!;

    // Price
    private PriceRepository _priceRepository = null!;
    private PriceService _priceService = null!;
    private PriceMapperHelper _priceMapperHelper = null!;

    // Common
    private CategoryTRepository _categoryTRepository = null!;
    private SubCategoryTRepository _subcategoryTRepository = null!;
    private BindCategoryRepository _bindCategoryRepository = null!;
    private CommonService _commonService = null!;
    private CommonMapperHelper _commonMapperHelper = null!;
    private CommonManager _commonManager = null!;

    [SetUp]
    public void Setup() {
        var dbEventOptions = new DbContextOptionsBuilder<EventFCSeafoodContext>();
        dbEventOptions.UseSqlServer(ConnectionString);
        _eventFcSeafoodContext = new EventFCSeafoodContext(dbEventOptions.Options);
        var dbCommonOptions = new DbContextOptionsBuilder<CommonFCSeafoodContext>();
        dbCommonOptions.UseSqlServer(ConnectionString);
        _commonFcSeafoodContext = new CommonFCSeafoodContext(dbCommonOptions.Options);
        var dbAuxiliaryOptions = new DbContextOptionsBuilder<AuxiliaryFCSeafoodContext>();
        dbAuxiliaryOptions.UseSqlServer(ConnectionString);
        _auxiliaryFcSeafoodContext = new AuxiliaryFCSeafoodContext(dbAuxiliaryOptions.Options);

        _itemRepository = new ItemRepository(_eventFcSeafoodContext);
        _priceRepository = new PriceRepository(_eventFcSeafoodContext);

        _priceMapperHelper = new PriceMapperHelper();
        _priceService = new PriceService(_priceMapperHelper, _priceRepository);
        _itemMapperHelper = new ItemMapperHelper(_priceService);
        _itemService = new ItemService(_itemMapperHelper, _itemRepository);
        _itemManager = new ItemManager(_itemService);

        _categoryTRepository = new CategoryTRepository(_commonFcSeafoodContext);
        _subcategoryTRepository = new SubCategoryTRepository(_commonFcSeafoodContext);
        _bindCategoryRepository = new BindCategoryRepository(_auxiliaryFcSeafoodContext);
        _commonMapperHelper = new CommonMapperHelper();
        _commonService = new CommonService(_commonMapperHelper, _bindCategoryRepository, _categoryTRepository, _subcategoryTRepository);
        _commonManager = new CommonManager(_commonService);
    }

    [Test]
    public async Task GetItemDbo() {
        Assert.Multiple(() => {
            Assert.That(_itemManager, Is.Not.Null);
        });

        var itemDbos = await _itemRepository.FindByConditionAsync(x => x.CategoryType == CategoryType.Fish && x.SubCategoryType == SubCategoryType.SeaFish);
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
            CategoryType = CategoryType.Fish, SubCategoryType = SubCategoryType.SeaFish
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
            Assert.That(_commonMapperHelper, Is.Not.Null);
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
}