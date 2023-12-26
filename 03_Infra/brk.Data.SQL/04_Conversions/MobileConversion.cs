using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Infra.Data.Sql._04_Conversions
{
    internal class MobileConversion : ValueConverter<Mobile, string>
    {
        public MobileConversion() : base(m => m.Value, m => Mobile.FromString(m))
        {

        }
    }
}
