namespace FCSeafood.DAL.Common.Repository;

public class ItemStatusTRepository : Base.BaseRepository<ItemStatusTDbo> {
    public ItemStatusTRepository(CommonFCSeafoodContext context) : base(context) { }

    public static (bool success, ItemStatusTModel model) ToModel(ItemStatusTDbo dbo) {
        if (dbo.Equals(null))
            return (false, new ItemStatusTModel());

        var model = new Mapper(MapperConfig.ConfigureCommon).Map<ItemStatusTModel>(dbo);
        return (true, model);
    }
}