namespace FCSeafood.DAL.Context;

public class CommonFCSeafoodContext : DbContext {
    public CommonFCSeafoodContext(DbContextOptions<CommonFCSeafoodContext> options) : base(options) { }

    public DbSet<CategoryTDbo> CategoryTypeDbos { get; set; }
    public DbSet<CurrencyCodeTDbo> CurrencyCodeTDbos { get; set; }
    public DbSet<GenderTDbo> GenderTDbos { get; set; }
    public DbSet<ItemStatusTDbo> ItemStatusTDbos { get; set; }
    public DbSet<RatingTDbo> RatingTDbos { get; set; }
    public DbSet<RoleTDbo> RoleTDbos { get; set; }
    public DbSet<SubcategoryTDbo> SubcategoryTypeDbos { get; set; }
    public DbSet<TemperatureUnitTDbo> TemperatureUnitTDbos { get; set; }
}