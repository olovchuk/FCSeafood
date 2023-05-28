namespace FCSeafood.DAL.Common.Repository.Base;

public abstract class BaseRepository<TEntity> where TEntity : class {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(TEntity));

    protected readonly CommonFCSeafoodContext Context;
    protected DbSet<TEntity> Entities { get; }

    protected BaseRepository(CommonFCSeafoodContext context) {
        this.Context = context;
        Entities = this.Context.Set<TEntity>();
    }

    protected virtual IQueryable<TEntity> NoTracking() => this.Entities.AsNoTracking();

    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync(bool skipNoneValues = true) {
        try {
            if (skipNoneValues) return await this.NoTracking().Skip(1).ToListAsync().ConfigureAwait(false);
            else return await this.NoTracking().ToListAsync().ConfigureAwait(false);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<TEntity>();
        }
    }

    public virtual async Task<TEntity?> FindByConditionAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate) {
        try {
            return await this.NoTracking().FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionListAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate) {
        try {
            return await this.NoTracking().Where(predicate).ToListAsync().ConfigureAwait(false);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<TEntity>();
        }
    }
}