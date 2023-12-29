using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Framework.Base.ValueConversion
{
    public sealed class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(m => m.Value, m => Title.FromString(m))
        {

        }
    }
}
