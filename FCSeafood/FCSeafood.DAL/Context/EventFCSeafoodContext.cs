namespace FCSeafood.DAL.Context;

public class EventFCSeafoodContext : DbContext {
    public EventFCSeafoodContext(DbContextOptions<EventFCSeafoodContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserCredential> UserCredentials { get; set; }
}