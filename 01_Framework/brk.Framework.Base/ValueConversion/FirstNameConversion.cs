using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Framework.Base.ValueConversion
{
    public sealed class FirstNameConversion : ValueConverter<FirstName, string>
    {
        public FirstNameConversion() : base(m => m.Value, m => FirstName.FromString(m))
        {

        }
    }
}
