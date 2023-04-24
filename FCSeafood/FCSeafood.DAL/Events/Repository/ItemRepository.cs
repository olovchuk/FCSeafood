namespace FCSeafood.DAL.Events.Repository;

public class ItemRepository : BaseRepository<ItemDbo> {
    public ItemRepository(EventFCSeafoodContext context) : base(context) { }
}