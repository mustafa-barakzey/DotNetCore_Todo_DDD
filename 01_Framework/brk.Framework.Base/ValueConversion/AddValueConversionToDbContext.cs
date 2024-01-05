using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace brk.Framework.Base.ValueConversion
{
    internal static class AddValueConversionToDbContext
    {
        public static void AddValueConversion(this ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
            configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
            configurationBuilder.Properties<Email>().HaveConversion<EmailConversion>();
            configurationBuilder.Properties<Mobile>().HaveConversion<MobileConversion>();
            configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
            configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
        }
    }
}
