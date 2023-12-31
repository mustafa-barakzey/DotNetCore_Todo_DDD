using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Data.SQL._01_Context;
using brk.Framework.Base.Data;
using brk.Framework.Base.ValueObjects;

namespace brk.Data.SQL.List.Data
{
    public class ListRepository:BaseRepository<TodoCommandDbContext,ListModel,long>,IListRepository
    {
        public ListRepository(TodoCommandDbContext context):base(context) { }

        public async Task<bool> IsExistAsync(ListOwnerId listOwnerId, Title title) => await _dbContext.UserList.AnyAsync(m => m.OwnerId == listOwnerId.Value && m.Title == title);
    }
}
