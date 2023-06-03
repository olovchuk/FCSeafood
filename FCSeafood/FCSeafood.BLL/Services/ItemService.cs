using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class ItemService {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                     .CreateLogger(typeof(ItemService));

    private readonly ItemRepository _itemRepository;

    public ItemService(ItemRepository itemRepository) {
        _itemRepository = itemRepository;
    }

    public async Task<ItemModel?> GetItemAsync(Guid id) {
        try {
            var itemDbo = await _itemRepository.FindByConditionAsync(x => x.Id == id);
            if (itemDbo is null)
                return null;

            var result = ItemRepository.ToModel(itemDbo);
            return result.success ? result.model : null;
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public async Task<IReadOnlyCollection<ItemModel>> GetItemListAsync(ItemFilterParams filter) {
        try {
            var itemListDbo = await _itemRepository.FindByConditionListAsync(
                x =>
                    x.CategoryTDboId == (int)filter.CategoryType
                 && x.SubcategoryTDboId == (int)filter.SubcategoryType
                 && (filter.PriceFrom > 0 && x.PriceDbo != null && x.PriceDbo.Price >= filter.PriceFrom)
                 && (filter.PriceTo > 0 && x.PriceDbo != null && x.PriceDbo.Price <= filter.PriceTo)
            );
            if (itemListDbo.Count == 0)
                return Array.Empty<ItemModel>();

            var result = ItemRepository.ToModel(itemListDbo);
            return result.success ? result.models : Array.Empty<ItemModel>();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Service.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<ItemModel>();
        }
    }
}