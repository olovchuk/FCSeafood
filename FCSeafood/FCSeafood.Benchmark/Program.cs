using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FCSeafood.BLL.Item;
using FCSeafood.BLL.Item.Models.Common;
using FCSeafood.BLL.Item.Models.Params;
using FCSeafood.BusinessObjects;
using FCSeafood.DAL.Context;
using Microsoft.EntityFrameworkCore;

BenchmarkRunner.Run<ItemBenchmark>();

[MemoryDiagnoser]
[RankColumn]
public class ItemBenchmark {
    private readonly ItemManager _itemManager;

    public ItemBenchmark(ItemManager itemManager) {
        _itemManager = itemManager;
    }

    public async Task GetItemListAsync() {
        var tmp = await _itemManager.GetItemListAsync(new ItemByFilterParams(new ItemFilterModel {
            CategoryType = CategoryType.Fish, SubCategoryType = SubCategoryType.RiverFish
        }));
    }
    
    public void GetItemList() {
        var tmp = _itemManager.GetItemListAsync(new ItemByFilterParams(new ItemFilterModel {
            CategoryType = CategoryType.Fish, SubCategoryType = SubCategoryType.RiverFish
        }));
    }
}