using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Framework.Base.ValueConversion
{
    public sealed class EmailConversion : ValueConverter<Email, string>
    {
        public EmailConversion() : base(m => m.Value, m => Email.FromString(m))
        {

        }
    }
}
