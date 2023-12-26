using brk.Core.Domain.User.Data;
using brk.Core.Domain.User.Entities;
using brk.Data.SQL._01_Context;
using brk.Framework.Base.ValueObjects;

namespace brk.Data.SQL.User.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoCommandDbContext _context;
        public UserRepository(TodoCommandDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserModel user) => await _context.Users.AddAsync(user);

        public async Task<bool> IsExistAsync(Email email) => await _context.Users.AnyAsync(m => m.Email == email);

        public int Commit() => _context.SaveChanges();

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
    }
}
