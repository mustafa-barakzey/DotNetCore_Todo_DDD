
using Microsoft.EntityFrameworkCore;

namespace brk.Framework.Base.Data
{
    public abstract class BaseCommandDbContext : DbContext
    {
        public BaseCommandDbContext(DbContextOptions options):base(options) { }
    }
}
