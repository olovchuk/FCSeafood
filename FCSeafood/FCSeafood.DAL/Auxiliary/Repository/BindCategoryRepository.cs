namespace FCSeafood.DAL.Auxiliary.Repository;

public class BindCategoryRepository {
    private readonly AuxiliaryFCSeafoodContext db;

    public BindCategoryRepository(AuxiliaryFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<IReadOnlyCollection<BindCategoryDbo>> GetAllAsync() => await db.BindCategories.AsNoTracking().ToListAsync().ConfigureAwait(false);
    public async Task<IReadOnlyCollection<BindCategoryDbo>> GetByCategoryTypeAsync(CategoryType categoryType) => await db.BindCategories.Where(x => x.CategoryType == categoryType).AsNoTracking().ToListAsync().ConfigureAwait(false);
    public async Task<IReadOnlyCollection<BindCategoryDbo>> GetBySubcategoryTypeAsync(SubcategoryType subcategoryType) => await db.BindCategories.Where(x => x.SubcategoryType == subcategoryType).AsNoTracking().ToListAsync().ConfigureAwait(false);
}