
using brk.Framework.Base.ValueConversion;
using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace brk.Framework.Base.Data
{
    public abstract class BaseCommandDbContext : DbContext
    {
        public BaseCommandDbContext(DbContextOptions options):base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
            configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
            configurationBuilder.Properties<Email>().HaveConversion<EmailConversion>();
            configurationBuilder.Properties<Mobile>().HaveConversion<MobileConversion>();
        }
    }
}
