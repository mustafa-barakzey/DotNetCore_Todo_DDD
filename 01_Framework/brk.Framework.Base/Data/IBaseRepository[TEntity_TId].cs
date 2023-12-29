using brk.Framework.Base.Domain;

namespace brk.Framework.Base.Data
{
    public interface IBaseRepository<TEntity, TId> : IUnitOfWork where TEntity : class, IAggregateRoot
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TId id);
        Task<TEntity?> GetByIdAsync(TId id);
    }

    public abstract class BaseRepository<TDbContext, TEntity, TId> :
       IUnitOfWork,
       IBaseRepository<TEntity, TId>
       where TDbContext : BaseCommandDbContext
       where TEntity : class, IAggregateRoot
    {
        protected readonly TDbContext _dbContext;

        protected BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TEntity entity) => await _dbContext.AddAsync(entity);

        public int Commit() => _dbContext.SaveChanges();

        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

        public Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
                throw new NullReferenceException(nameof(TEntity));
            await DeleteAsync(entity);
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
    }
}
