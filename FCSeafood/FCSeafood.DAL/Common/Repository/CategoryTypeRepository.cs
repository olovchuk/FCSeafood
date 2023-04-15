namespace FCSeafood.DAL.Common.Repository;

public class CategoryTypeRepository {
    private readonly CommonFCSeafoodContext db;

    public CategoryTypeRepository(CommonFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<List<CategoryTypeDbo>> GetAll() => await db.CategoryTypeDbos.AsNoTracking().ToListAsync().ConfigureAwait(false);
}