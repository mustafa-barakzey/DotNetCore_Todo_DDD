using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Framework.Base.ValueConversion
{
    public sealed class DescriptionConversion : ValueConverter<Description, string>
    {
        public DescriptionConversion() : base(m => m.Value, m => Description.FromString(m))
        {

        }
    }
}
