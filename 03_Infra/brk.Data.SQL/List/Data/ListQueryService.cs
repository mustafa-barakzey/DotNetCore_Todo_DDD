using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Entities;
using brk.Data.SQL._01_Context;
using brk.Framework.Base.Data.Query;

namespace brk.Data.SQL.List.Data
{
    public class ListQueryService : BaseQueryService<TodoQueryDbContext>, IListQueryService
    {
        public ListQueryService(TodoQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ListModel?> GetAsync(long userId, long id) => await _dbContext.UserList.FirstOrDefaultAsync(m => m.OwnerId == userId && m.Id == id);

        public async Task<List<ListModel>> GetByUserIdAsync(long userId)=>await _dbContext.UserList.Where(m=>m.OwnerId == userId).ToListAsync();
    }
}
