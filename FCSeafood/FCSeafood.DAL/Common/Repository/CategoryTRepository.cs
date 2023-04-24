namespace FCSeafood.DAL.Common.Repository;

public class CategoryTRepository : DAL.Common.Repository.Base.BaseRepository<CategoryTDbo> {
    public CategoryTRepository(CommonFCSeafoodContext context) : base(context) { }
}