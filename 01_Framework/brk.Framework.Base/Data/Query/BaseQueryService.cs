namespace brk.Framework.Base.Data.Query
{
    public abstract class BaseQueryService<TDbContext> where TDbContext : BaseQueryDbContext
    {
        protected TDbContext _dbContext;

        public BaseQueryService(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
