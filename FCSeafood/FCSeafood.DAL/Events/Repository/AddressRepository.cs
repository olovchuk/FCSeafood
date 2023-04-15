namespace FCSeafood.DAL.Events.Repository;

public class AddressRepository {
    private readonly ILogger log = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(AddressRepository));

    private readonly EventFCSeafoodContext db;

    public AddressRepository(EventFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<Address?> GetByIdAsync(Guid id) => await db.Addresses.Where(a => a.Id.Equals(id)).FirstOrDefaultAsync().ConfigureAwait(false);

    public async Task SaveAsync(Address address) {
        if (!address.Equals(null)) {
            try {
                db.Addresses.Add(address);
                await db.SaveChangesAsync();
            } catch (Exception ex) { log.LogError($"Catch error during Add/SaveChanges to database;\r\nAddress ID: [{address.Id}]\r\nError: [{ex.Message}]"); }
        }
        else { log.LogError("Failed to save address;\r\nAddress: [NULL]"); }
    }
}