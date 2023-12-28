using brk.Core.Domain.User.Data;
using brk.Core.Domain.User.Entities;
using brk.Data.SQL._01_Context;
using brk.Framework.Base.Data;
using brk.Framework.Base.ValueObjects;

namespace brk.Data.SQL.User.Data
{
    public class UserRepository : BaseRepository<TodoCommandDbContext>, IUserRepository
    {
        public UserRepository(TodoCommandDbContext context):base(context)
        {
        }

        public async Task AddAsync(UserModel user) => await _dbContext.Users.AddAsync(user);

        public async Task<bool> IsExistAsync(Email email) => await _dbContext.Users.AnyAsync(m => m.Email == email);
    }
}
