using System.Linq.Expressions;
using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class ItemService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(ItemService));

    private readonly ItemMapperHelper _itemMapperHelper;
    private readonly ItemRepository _itemRepository;

    public ItemService(ItemMapperHelper itemMapperHelper, ItemRepository itemRepository) {
        _itemMapperHelper = itemMapperHelper;
        _itemRepository = itemRepository;
    }

    public async Task<ItemModel?> GetItemAsync(Guid id) {
        try {
            var itemDbo = await _itemRepository.FindByConditionAsync(x => x.Id == id);
            if (itemDbo is null) return null;

            var result = await _itemMapperHelper.ToModel(itemDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<IReadOnlyCollection<ItemModel>> GetItemListAsync(ItemFilterModel filterModel) {
        try {
            var itemListDbo = await _itemRepository.FindByConditionListAsync(x => x.CategoryType == filterModel.CategoryType && x.SubcategoryType == filterModel.SubcategoryType);
            if (itemListDbo.Count == 0) return Array.Empty<ItemModel>();

            var result = await _itemMapperHelper.ToModel(itemListDbo);
            return result.success ? result.models : Array.Empty<ItemModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<ItemModel>();
        }
    }
}