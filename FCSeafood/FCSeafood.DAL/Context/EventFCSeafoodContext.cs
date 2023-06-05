namespace FCSeafood.DAL.Context;

public class EventFCSeafoodContext : DbContext {
    public EventFCSeafoodContext(DbContextOptions<EventFCSeafoodContext> options) : base(options) { }

    public DbSet<AddressDbo> Addresses { get; set; }
    public DbSet<ItemDbo> Items { get; set; }
    public DbSet<OrderEntityDbo> OrderEntities { get; set; }
    public DbSet<OrderDbo> Orders { get; set; }
    public DbSet<UserCredentialDbo> UserCredentials { get; set; }
    public DbSet<UserDbo> Users { get; set; }
}