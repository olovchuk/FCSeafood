namespace FCSeafood.DAL.Common.Repository.Base;

public abstract class BaseRepository<TEntity> where TEntity : class {
    protected readonly CommonFCSeafoodContext context;
    protected DbSet<TEntity> Entities { get; }

    protected BaseRepository(CommonFCSeafoodContext context) {
        this.context = context;
        Entities = this.context.Set<TEntity>();
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() {
        return await this.Entities.Skip(1).AsNoTracking().ToListAsync().ConfigureAwait(false);
    }
}