namespace brk.Framework.Base.Data
{
    public interface IBaseRepository : IUnitOfWork
    {

    }

    public abstract class BaseRepository<TDbContext> :
        IUnitOfWork,
        IBaseRepository
        where TDbContext : BaseCommandDbContext
    {
        protected readonly TDbContext _dbContext;

        protected BaseRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit() => _dbContext.SaveChanges();

        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();
    }
}
