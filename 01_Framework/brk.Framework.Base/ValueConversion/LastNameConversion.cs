using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Framework.Base.ValueConversion
{
    public sealed class LastNameConversion : ValueConverter<LastName, string>
    {
        public LastNameConversion() : base(m => m.Value, m => LastName.FromString(m))
        {

        }
    }
}
