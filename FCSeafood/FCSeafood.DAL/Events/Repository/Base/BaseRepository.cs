using System.Linq.Expressions;

namespace FCSeafood.DAL.Events.Repository.Base;

public abstract class BaseRepository<TEntity> where TEntity : class {
    private readonly ILogger _loggger = LoggerFactory.Create(b => { b.AddConsole(); }).CreateLogger(typeof(TEntity));

    protected readonly EventFCSeafoodContext Context;
    protected DbSet<TEntity> Entities { get; }

    protected BaseRepository(EventFCSeafoodContext context) {
        this.Context = context;
        Entities = this.Context.Set<TEntity>();
    }

    protected IQueryable<TEntity> NoTracking() => this.Entities.AsNoTracking();

    public virtual async Task InsertAsync(TEntity data) {
        try {
            await this.Entities.AddAsync(data).ConfigureAwait(false);
            await this.Context.SaveChangesAsync();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
        }
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() {
        try {
            return await this.NoTracking().ToListAsync().ConfigureAwait(false);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<TEntity>();
        }
    }

    public virtual async Task<TEntity?> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate) {
        try {
            return await this.NoTracking().FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
            return null;
        }
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionListAsync(Expression<Func<TEntity, bool>> predicate) {
        try {
            return await this.NoTracking().Where(predicate).ToListAsync().ConfigureAwait(false);
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
            return Array.Empty<TEntity>();
        }
    }

    public virtual async Task UpdateAsync(TEntity data) {
        try {
            this.Entities.Update(data);
            await this.Context.SaveChangesAsync();
        } catch (Exception ex) {
            _loggger.LogError($"{ErrorMessage.Repository.Global}\r\nError: [{ex.Message}]");
        }
    }
}