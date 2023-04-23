namespace FCSeafood.DAL.Events.Repository;

public class ItemRepository : BaseRepository<Item> {
    public ItemRepository(EventFCSeafoodContext context) : base(context) { }
}