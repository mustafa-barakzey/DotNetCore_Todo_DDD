using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Core.Domain.User.Entities;
using brk.Core.Domain.User.ValueObjects;
using brk.Data.SQL.List.Conversion;
using brk.Framework.Base.Data;
using brk.Infra.Data.Sql._04_Conversions;

namespace brk.Data.SQL._01_Context
{
    public class TodoCommandDbContext : BaseCommandDbContext
    {
        public TodoCommandDbContext(DbContextOptions<TodoCommandDbContext> options) : base(options) { }

        #region properties

        /// <summary>کاربران</summary>
        public DbSet<UserModel> Users { get; set; }

        /// <summary>لیست های ساخته شده توسط کاربران</summary>
        public DbSet<ListModel> UserList { get; set; }

        #endregion

        #region configuration

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<Password>().HaveConversion<PasswordConversion>();
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
