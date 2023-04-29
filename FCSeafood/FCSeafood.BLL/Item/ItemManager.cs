namespace FCSeafood.BLL.Item;

public class ItemManager {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(ItemManager));

    private readonly ItemService _itemService;

    public ItemManager(ItemService itemService) {
        _itemService = itemService;
    }

    public async Task<ItemListResponse> GetItemListAsync(ItemByFilterParams itemByFilterParams) {
        try {
            var itemListModel = await _itemService.GetItemListAsync(itemByFilterParams.ItemFilterModel);
            return new ItemListResponse(true, "", itemListModel);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Manager.Global}\r\nError: [{ex.Message}]");
            return new ItemListResponse(false, ErrorMessage.Item.IsNotDefined, Enumerable.Empty<ItemModel>());
        }
    }
}