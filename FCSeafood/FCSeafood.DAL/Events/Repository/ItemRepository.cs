namespace FCSeafood.DAL.Events.Repository; 

public class ItemRepository {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(ItemRepository));

    private readonly EventFCSeafoodContext db;

    public ItemRepository(EventFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<Item?> GetByIdAsync(Guid id) => await db.Items.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync().ConfigureAwait(false);

    public async Task SaveAsync(Item item) {
        if (!item.Equals(null)) {
            try {
                db.Items.Add(item);
                await db.SaveChangesAsync();
            } catch (Exception ex) { log.LogError($"Catch error during Add/SaveChanges to database;\r\nItem ID: [{item.Id}]\r\nError: [{ex.Message}]"); }
        }
        else { log.LogError("Failed to save item;\r\nItem: [NULL]"); }
    }
}