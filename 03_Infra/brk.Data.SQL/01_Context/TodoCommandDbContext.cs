using brk.Core.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace brk.Data.SQL._01_Context
{
    public class TodoCommandDbContext:DbContext
    {
        public TodoCommandDbContext(DbContextOptions<TodoCommandDbContext> options):base(options){}

        #region properties


        #endregion

        #region configuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
