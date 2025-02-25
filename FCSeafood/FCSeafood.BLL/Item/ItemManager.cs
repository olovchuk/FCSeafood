namespace FCSeafood.BLL.Item;

public class ItemManager {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(ItemManager));

    private readonly ItemService _itemService;

    public ItemManager(ItemService itemService) {
        _itemService = itemService;
    }

    public async Task<ItemResponse> GetItemAsync(ItemCodeParams itemCodeParams) {
        try {
            var itemModel = await _itemService.GetItemByCodeAsync(itemCodeParams.Code);
            return new ItemResponse(true, "", itemModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new ItemResponse(false, ErrorMessage.Item.IsNotDefined, null);
        }
    }

    public async Task<ItemListResponse> GetItemListAsync(ItemFilterParams itemByFilterParams) {
        try {
            var itemListModel = await _itemService.GetItemListAsync(itemByFilterParams);
            return new ItemListResponse(true, "", itemListModel);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new ItemListResponse(false, ErrorMessage.Item.IsNotDefined, Enumerable.Empty<ItemModel>());
        }
    }

    public async Task<RatingTResponse> GetItemRatingAsync(GetItemRatingParams getItemRatingParams) {
        try {
            var ratingType = await _itemService.GetItemRatingAsync(getItemRatingParams.UserId, getItemRatingParams.ItemId);
            return new RatingTResponse(true, "", ratingType);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
            return new RatingTResponse(false, ErrorMessage.Order.FindRatingFailed, null);
        }
    }

    public async Task SetItemRatingAsync(SetItemRatingParams setItemRatingParams) {
        try {
            await _itemService.SetItemRatingAsync(
                setItemRatingParams.UserId
              , setItemRatingParams.ItemId
              , setItemRatingParams.RatingType
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Manager.Global, ex.Message);
        }
    }
}