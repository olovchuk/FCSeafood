namespace FCSeafood.DAL.Context;

public class CommonFCSeafoodContext : DbContext {
    public CommonFCSeafoodContext(DbContextOptions<CommonFCSeafoodContext> options) : base(options) { }

    public DbSet<CategoryTDbo> CategoryTypeDbos { get; set; }
    public DbSet<SubCategoryTDbo> SubCategoryTypeDbos { get; set; }
}