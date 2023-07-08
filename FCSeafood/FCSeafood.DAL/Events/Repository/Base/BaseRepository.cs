using System.Linq.Expressions;

namespace FCSeafood.DAL.Events.Repository.Base;

public abstract class BaseRepository<TEntity, TModel> where TEntity : class, new()
                                                      where TModel : class, new() {
    private readonly ILogger _logger = LoggerFactory.Create(b => { b.AddConsole(); })
                                                    .CreateLogger(typeof(TEntity));

    protected readonly EventFCSeafoodContext Context;
    protected DbSet<TEntity> Entities { get; }

    protected BaseRepository(EventFCSeafoodContext context) {
        this.Context = context;
        Entities = this.Context.Set<TEntity>();
    }

    protected virtual IQueryable<TEntity> NoTracking() => this.Entities.AsNoTracking();

    public virtual async Task<(bool isSuccessful, TModel? model)> InsertAsync(TEntity entity) {
        try {
            await this.Entities.AddAsync(entity).ConfigureAwait(false);
            await this.Context.SaveChangesAsync();
            return ToModel(entity);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
            return (false, null);
        }
    }

    public virtual async Task<(bool isSuccessful, TModel? model)> InsertAsync(TModel model) {
        try {
            var (isSuccessful, entity) = ToDbo(model);
            if (!isSuccessful)
                return (false, null);

            await this.Entities.AddAsync(entity!).ConfigureAwait(false);
            await this.Context.SaveChangesAsync();
            return ToModel(entity);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
            return (false, null);
        }
    }

    public virtual async Task<(bool isSuccessful, IReadOnlyCollection<TModel> models)> GetAllAsync() {
        try {
            return ToModel(await this.NoTracking().ToListAsync().ConfigureAwait(false));
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
            return (false, Array.Empty<TModel>());
        }
    }

    public virtual async Task<(bool isSuccessful, TModel? model)>
        FindByConditionAsync(Expression<Func<TEntity, bool>> predicate) {
        try {
            return ToModel(await this.NoTracking().FirstOrDefaultAsync(predicate).ConfigureAwait(false));
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
            return (false, null);
        }
    }

    public virtual async Task<(bool isSuccessful, IReadOnlyCollection<TModel> models)> FindByConditionListAsync(
        Expression<Func<TEntity, bool>> predicate
    ) {
        try {
            return ToModel(await this.NoTracking().Where(predicate).ToListAsync().ConfigureAwait(false));
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
            return (false, Array.Empty<TModel>());
        }
    }

    public virtual async Task UpdateAsync(TEntity entity) {
        try {
            this.Entities.Update(entity);
            await this.Context.SaveChangesAsync();
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
        }
    }

    public virtual async Task UpdateAsync(TModel model) {
        try {
            var (isSuccessful, entity) = ToDbo(model);
            if (!isSuccessful)
                return;

            this.Entities.Update(entity!);
            await this.Context.SaveChangesAsync();
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
        }
    }

    public virtual async Task RemoveAsync(TEntity entity) {
        try {
            this.Entities.Remove(entity);
            await this.Context.SaveChangesAsync();
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
        }
    }

    public virtual async Task RemoveAsync(TModel model) {
        try {
            var (isSuccessful, entity) = ToDbo(model);
            if (!isSuccessful)
                return;

            this.Entities.Remove(entity!);
            await this.Context.SaveChangesAsync();
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
        }
    }

    public virtual async Task RemoveRangeAsync(IReadOnlyCollection<TModel> models) {
        try {
            var (isSuccessful, entities) = ToDbo(models);
            if (!isSuccessful)
                return;

            this.Entities.RemoveRange(entities);
            await this.Context.SaveChangesAsync();
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
        }
    }

    public (bool isSuccessful, TEntity? entity) ToDbo(TModel? model) {
        if (model is null)
            return (false, null);

        try {
            return Activator.CreateInstance(typeof(TEntity), model) is not TEntity entity ?
                (false, new TEntity()) : (true, entity);
        } catch (Exception ex) {
            _logger.LogError("{Global}\\r\\nError: [{ExMessage}]", ErrorMessage.Repository.Global, ex.Message);
            return (false, null);
        }
    }

    public (bool isSuccessful, IReadOnlyCollection<TEntity> models) ToDbo(IReadOnlyCollection<TModel>? models) {
        if (models is null)
            return (false, Array.Empty<TEntity>());

        var listResult = new List<TEntity>();
        foreach (var model in models) {
            var (isSuccessful, dbo) = ToDbo(model);
            if (!isSuccessful)
                return (false, Array.Empty<TEntity>());
            listResult.Add(dbo!);
        }

        return (true, listResult);
    }

    public (bool isSuccessful, TModel? model) ToModel(TEntity? entity) {
        if (entity is null)
            return (false, null);

        var model = new Mapper(MapperConfig.ConfigureEvent).Map<TModel>(entity);
        AddExtensionToModel(ref model, entity);
        return (true, model);
    }

    public (bool isSuccessful, IReadOnlyCollection<TModel> models) ToModel(IReadOnlyCollection<TEntity>? entities) {
        if (entities is null)
            return (false, Array.Empty<TModel>());

        var listResult = new List<TModel>();
        foreach (var dbo in entities) {
            var (isSuccessful, model) = ToModel(dbo);
            if (!isSuccessful)
                return (false, Array.Empty<TModel>());
            listResult.Add(model!);
        }

        return (true, listResult);
    }

    protected virtual void AddExtensionToModel(ref TModel model, TEntity entity) { }
}