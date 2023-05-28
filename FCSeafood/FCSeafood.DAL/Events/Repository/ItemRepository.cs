namespace FCSeafood.DAL.Events.Repository;

public class ItemRepository : Base.BaseRepository<ItemDbo> {
    public ItemRepository(EventFCSeafoodContext context) : base(context) { }

    protected override IQueryable<ItemDbo> NoTracking() => this.Entities.Include(x => x.PriceDbo).ThenInclude(x => x!.CurrencyCodeTDbo).Include(x => x.CategoryTDbo).Include(x => x.SubcategoryTDbo).Include(x => x.ItemStatusTDbo).Include(x => x.TemperatureUnitTDbo).AsNoTracking();

    public static (bool success, ItemModel model) ToModel(ItemDbo dbo) {
        if (dbo.Equals(null)) return (false, new ItemModel());

        var model = new Mapper(MapperConfig.ConfigureEvent).Map<ItemModel>(dbo);

        if (dbo.PriceDbo != null) {
            var result = PriceRepository.ToModel(dbo.PriceDbo);
            if (result.success) model.Price = result.model;
        }

        if (dbo.CategoryTDbo != null) {
            var result = CategoryTRepository.ToModel(dbo.CategoryTDbo);
            if (result.success) model.Category = result.model;
        }

        if (dbo.SubcategoryTDbo != null) {
            var result = SubcategoryTRepository.ToModel(dbo.SubcategoryTDbo);
            if (result.success) model.Subcategory = result.model;
        }

        if (dbo.ItemStatusTDbo != null) {
            var result = ItemStatusTRepository.ToModel(dbo.ItemStatusTDbo);
            if (result.success) model.ItemStatus = result.model;
        }

        if (dbo.TemperatureUnitTDbo != null) {
            var result = TemperatureUnitTRepository.ToModel(dbo.TemperatureUnitTDbo);
            if (result.success) model.TemperatureUnit = result.model;
        }

        return (true, model);
    }

    public static (bool success, IReadOnlyCollection<ItemModel> models) ToModel(IEnumerable<ItemDbo> listDbo) {
        if (listDbo.Equals(null)) return (false, Array.Empty<ItemModel>());

        var listResult = new List<ItemModel>();
        foreach (var dbo in listDbo) {
            var result = ToModel(dbo);
            if (!result.success) return (false, Array.Empty<ItemModel>());
            listResult.Add(result.model);
        }

        return (true, listResult);
    }
}