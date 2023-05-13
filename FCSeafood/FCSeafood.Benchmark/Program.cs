using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FCSeafood.BLL.Helpers;
using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Common;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BLL.Services;
using FCSeafood.BusinessObjects;
using FCSeafood.DAL.Context;
using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;
using Microsoft.EntityFrameworkCore;

BenchmarkRunner.Run<ItemBenchmark>();

[MemoryDiagnoser]
[RankColumn]
public class ItemBenchmark {
    private const string ConnectionString = "Data Source=localhost;Initial Catalog=Test;User ID=FCS_User;Password=s1c@r8;TrustServerCertificate=True";
    private readonly ItemManager _itemManager;

    public ItemBenchmark() {
        var dbEventOptions = new DbContextOptionsBuilder<EventFCSeafoodContext>();
        dbEventOptions.UseSqlServer(ConnectionString);
        var eventFcSeafoodContext = new EventFCSeafoodContext(dbEventOptions.Options);

        var priceRepository = new PriceRepository(eventFcSeafoodContext);
        var priceMapperHelper = new PriceMapperHelper();
        var priceService = new PriceService(priceMapperHelper, priceRepository);
        var itemMapperHelper = new ItemMapperHelper(priceService);
        var itemRepository = new ItemRepository(eventFcSeafoodContext);
        var itemService = new ItemService(itemMapperHelper, itemRepository);
        _itemManager = new ItemManager(itemService);
    }

    [Benchmark]
    public async Task GetItemListAsync() {
        var tmp = await _itemManager.GetItemListAsync(new ItemByFilterParams(new ItemFilterModel {
            CategoryType = CategoryType.Fish, SubcategoryType = SubcategoryType.RiverFish
        }));
    }
}