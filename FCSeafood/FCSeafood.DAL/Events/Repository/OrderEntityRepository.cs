using Microsoft.Extensions.DependencyInjection;

namespace FCSeafood.DAL.Events.Repository;

public class OrderEntityRepository : Base.BaseRepository<OrderEntityDbo, OrderEntityModel> {
    private readonly ItemRepository _itemRepository;

    public OrderEntityRepository(EventFCSeafoodContext context, IServiceProvider provider) : base(context) {
        _itemRepository = provider.GetService<ItemRepository>()!;
    }

    protected override IQueryable<OrderEntityDbo> NoTracking() =>
        this.Entities
            .Include(x => x.ItemDbo)
            .Include(x => x.ItemDbo!.CategoryTDbo)
            .Include(x => x.ItemDbo!.SubcategoryTDbo)
            .Include(x => x.ItemDbo!.ItemStatusTDbo)
            .Include(x => x.ItemDbo!.TemperatureUnitTDbo)
            .AsNoTracking();

    protected override void AddExtensionToModel(ref OrderEntityModel orderEntityModel, OrderEntityDbo entity) {
        if (entity.ItemDbo != null) {
            var (isSuccessful, model) = _itemRepository.ToModel(entity.ItemDbo);
            if (isSuccessful)
                orderEntityModel.Item = model;
        }
    }
}