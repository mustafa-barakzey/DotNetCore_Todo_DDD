using brk.Core.Domain.User.Entities;
using brk.Core.Domain.User.ValueObjects;
using brk.Framework.Base.Data;
using brk.Framework.Base.ValueObjects;
using brk.Infra.Data.Sql._04_Conversions;

namespace brk.Data.SQL._01_Context
{
    public class TodoCommandDbContext : BaseCommandDbContext
    {
        public TodoCommandDbContext(DbContextOptions<TodoCommandDbContext> options) : base(options) { }

        #region properties

        public DbSet<UserModel> Users { get; set; }

        #endregion

        #region configuration

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
            configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
            configurationBuilder.Properties<Email>().HaveConversion<EmailConversion>();
            configurationBuilder.Properties<Mobile>().HaveConversion<MobileConversion>();
            configurationBuilder.Properties<Password>().HaveConversion<PasswordConversion>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
