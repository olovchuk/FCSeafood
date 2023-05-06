using System.Text.Json;
using FCSeafood.BLL.Helpers;
using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Common;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BLL.Services;
using FCSeafood.BusinessObjects;
using FCSeafood.BusinessObjects.Models.Events;
using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Repository;
using Microsoft.EntityFrameworkCore;

namespace FCSeafood.Test;

public class Tests {
    private const string ConnectionString = "Data Source=localhost;Initial Catalog=Test;User ID=FCS_User;Password=s1c@r8;TrustServerCertificate=True";
    private EventFCSeafoodContext _eventFcSeafoodContext = null!;

    // Item
    private ItemRepository _itemRepository = null!;
    private ItemService _itemService = null!;
    private ItemMapperHelper _itemMapperHelper = null!;
    private ItemManager _itemManager = null!;

    // Price
    private PriceRepository _priceRepository = null!;
    private PriceService _priceService = null!;
    private PriceMapperHelper _priceMapperHelper = null!;

    [SetUp]
    public void Setup() {
        var dbEventOptions = new DbContextOptionsBuilder<EventFCSeafoodContext>();
        dbEventOptions.UseSqlServer(ConnectionString);
        _eventFcSeafoodContext = new EventFCSeafoodContext(dbEventOptions.Options);

        _itemRepository = new ItemRepository(_eventFcSeafoodContext);
        _priceRepository = new PriceRepository(_eventFcSeafoodContext);

        _priceMapperHelper = new PriceMapperHelper();
        _priceService = new PriceService(_priceMapperHelper, _priceRepository);
        _itemMapperHelper = new ItemMapperHelper(_priceService);
        _itemService = new ItemService(_itemMapperHelper, _itemRepository);
        _itemManager = new ItemManager(_itemService);
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
}