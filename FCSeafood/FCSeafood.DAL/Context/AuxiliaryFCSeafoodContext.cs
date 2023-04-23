using FCSeafood.DAL.Auxiliary.Models;

namespace FCSeafood.DAL.Context;

public class AuxiliaryFCSeafoodContext : DbContext {
    public AuxiliaryFCSeafoodContext(DbContextOptions<AuxiliaryFCSeafoodContext> options) : base(options) { }

    public DbSet<BindCategory> BindCategories { get; set; }
}