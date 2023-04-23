namespace FCSeafood.DAL.Common.Repository;

public class CategoryTypeRepository : DAL.Common.Repository.Base.BaseRepository<CategoryTypeDbo> {
    public CategoryTypeRepository(CommonFCSeafoodContext context) : base(context) { }
}