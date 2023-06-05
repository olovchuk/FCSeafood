namespace FCSeafood.BLL.Item;

public class ItemManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(ItemManager));

    private readonly ItemService _itemService;

    public ItemManager(ItemService itemService) {
        _itemService = itemService;
    }

    public async Task<ItemListResponse> GetItemListAsync(ItemFilterParams itemByFilterParams) {
        try {
            var itemListModel = await _itemService.GetItemListAsync(itemByFilterParams);
            return new ItemListResponse(true, "", itemListModel);
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new ItemListResponse(false, ErrorMessage.Item.IsNotDefined, Enumerable.Empty<ItemModel>());
        }
    }
}