using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Infra.Data.Sql._04_Conversions
{
    internal class LastNameConversion : ValueConverter<LastName, string>
    {
        public LastNameConversion() : base(m => m.Value, m => LastName.FromString(m))
        {

        }
    }
}
