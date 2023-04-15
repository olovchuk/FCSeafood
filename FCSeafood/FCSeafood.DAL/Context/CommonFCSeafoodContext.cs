namespace FCSeafood.DAL.Context;

public class CommonFCSeafoodContext : DbContext {
    public CommonFCSeafoodContext(DbContextOptions<CommonFCSeafoodContext> options) : base(options) { }

    public DbSet<CategoryTypeDbo> CategoryTypeDbos { get; set; }
}