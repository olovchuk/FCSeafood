namespace FCSeafood.DAL.Common.Repository;

public class SubCategoryTypeRepository {
    private readonly CommonFCSeafoodContext db;

    public SubCategoryTypeRepository(CommonFCSeafoodContext db) {
        this.db = db;
    }

    public async Task<List<SubCategoryTypeDbo>> GetAll() => await db.SubCategoryTypeDbos.AsNoTracking().ToListAsync().ConfigureAwait(false);
}