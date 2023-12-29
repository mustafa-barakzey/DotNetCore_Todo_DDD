using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Framework.Base.ValueConversion
{
    public sealed class MobileConversion : ValueConverter<Mobile, string>
    {
        public MobileConversion() : base(m => m.Value, m => Mobile.FromString(m))
        {

        }
    }
}
