namespace FCSeafood.DAL.Auxiliary.Repository;

public class BindCategoryRepository {
    private readonly AuxiliaryFCSeafoodContext db;

    public BindCategoryRepository(AuxiliaryFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<List<BindCategory>> GetByCategoryType(CategoryType categoryType) => await db.BindCategories.Where(x => x.CategoryType == categoryType).AsNoTracking().ToListAsync().ConfigureAwait(false);
    public async Task<List<BindCategory>> GetBySubCategoryType(SubCategoryType subCategoryType) => await db.BindCategories.Where(x => x.SubCategoryType == subCategoryType).AsNoTracking().ToListAsync().ConfigureAwait(false);
}