using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Infra.Data.Sql._04_Conversions
{
    internal class EmailConversion : ValueConverter<Email, string>
    {
        public EmailConversion() : base(m => m.Value, m => Email.FromString(m))
        {

        }
    }
}
