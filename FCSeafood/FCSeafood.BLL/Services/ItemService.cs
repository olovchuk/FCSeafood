using System.Linq.Expressions;
using FCSeafood.DAL.Events.Models;
using FCSeafood.DAL.Events.Repository;

namespace FCSeafood.BLL.Services;

public class ItemService {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(ItemService));

    private readonly ItemRepository _itemRepository;
    private readonly RatingLRepository _ratingLRepository;

    public ItemService(ItemRepository itemRepository, RatingLRepository ratingLRepository) {
        _itemRepository = itemRepository;
        _ratingLRepository = ratingLRepository;
    }

    public async Task<ItemModel?> GetItemAsync(Guid id) {
        try {
            var (_, model) = await _itemRepository.FindByConditionAsync(x => x.Id == id);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<ItemModel?> GetItemByCodeAsync(string code) {
        try {
            var (_, model) = await _itemRepository.FindByConditionAsync(x => x.Code == code);
            return model;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return null;
        }
    }

    public async Task<IReadOnlyCollection<ItemModel>> GetItemListAsync(ItemFilterParams filter) {
        try {
            Expression<Func<ItemDbo, bool>> predicate = x =>
                x.CategoryTDboId == (int)filter.CategoryType
             && x.SubcategoryTDboId == (int)filter.SubcategoryType
             && (filter.PriceFrom < 0 || x.Price >= filter.PriceFrom)
             && (filter.PriceTo < 0 || x.Price <= filter.PriceTo);

            IReadOnlyCollection<ItemModel> models;
            if (filter.SortDirectionType == SortDirectionType.NoSort) {
                (_, models) = await _itemRepository.FindByConditionListAsync(predicate);
            } else {
                (_, models) = await _itemRepository.FindByConditionListSortPriceAsync(
                    predicate
                  , filter.SortDirectionType == SortDirectionType.Ascending
                );
            }

            return models;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return Array.Empty<ItemModel>();
        }
    }

    public async Task<RatingType> GetItemRatingAsync(Guid userId, Guid itemId) {
        try {
            var (isSuccessful, model) = await _ratingLRepository.FindByConditionAsync(
                x => x.UserDboId == userId && x.ItemDboId == itemId
            );
            return isSuccessful ? model!.Rating : RatingType.Unknown;
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
            return RatingType.Unknown;
        }
    }

    public async Task SetItemRatingAsync(Guid userId, Guid itemId, RatingType ratingType) {
        try {
            var (isSuccessful, model) = await _ratingLRepository.FindByConditionAsync(
                x => x.UserDboId == userId && x.ItemDboId == itemId
            );
            if (isSuccessful) {
                model!.Rating = ratingType;
                await _ratingLRepository.UpdateAsync(model);
                return;
            }

            await _ratingLRepository.InsertAsync(
                new RatingLDbo {
                    UserDboId = userId
                  , ItemDboId = itemId
                  , RatingTDboId = (int)ratingType
                }
            );
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Service.Global, ex.Message);
        }
    }
}