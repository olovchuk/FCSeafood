using System.Linq.Expressions;

namespace FCSeafood.DAL.Events.Repository;

public class ItemRepository : Base.BaseRepository<ItemDbo, ItemModel> {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(ItemRepository));

    public ItemRepository(EventFCSeafoodContext context) : base(context) { }

    protected override IQueryable<ItemDbo> NoTracking() =>
        this.Entities
            .Include(x => x.CategoryTDbo)
            .Include(x => x.SubcategoryTDbo)
            .Include(x => x.ItemStatusTDbo)
            .Include(x => x.TemperatureUnitTDbo)
            .AsNoTracking();

    protected override void AddExtensionToModel(ref ItemModel itemModel, ItemDbo entity) {
        if (entity.CategoryTDbo != null) {
            var (isSuccessful, model) = CategoryTRepository.ToModel(entity.CategoryTDbo);
            if (isSuccessful)
                itemModel.Category = model;
        }

        if (entity.SubcategoryTDbo != null) {
            var (isSuccessful, model) = SubcategoryTRepository.ToModel(entity.SubcategoryTDbo);
            if (isSuccessful)
                itemModel.Subcategory = model;
        }

        if (entity.ItemStatusTDbo != null) {
            var (isSuccessful, model) = ItemStatusTRepository.ToModel(entity.ItemStatusTDbo);
            if (isSuccessful)
                itemModel.ItemStatus = model;
        }

        if (entity.TemperatureUnitTDbo != null) {
            var (isSuccessful, model) = TemperatureUnitTRepository.ToModel(entity.TemperatureUnitTDbo);
            if (isSuccessful)
                itemModel.TemperatureUnit = model;
        }
    }

    public async Task<(bool isSuccessful, IReadOnlyCollection<ItemModel> models)> FindByConditionListSortPriceAsync(
        Expression<Func<ItemDbo, bool>> predicate
      , bool isAscending = true
    ) {
        try {
            if (isAscending)
                return ToModel(
                    await NoTracking()
                         .Where(predicate)
                         .OrderBy(x => x.Price)
                         .ToListAsync()
                         .ConfigureAwait(false)
                );

            return ToModel(
                await NoTracking()
                     .Where(predicate)
                     .OrderByDescending(x => x.Price)
                     .ToListAsync()
                     .ConfigureAwait(false)
            );
        } catch (Exception ex) {
            _logger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
            return (false, Array.Empty<ItemModel>());
        }
    }
}