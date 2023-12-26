using brk.Framework.Base.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Infra.Data.Sql._04_Conversions
{
    internal class FirstNameConversion : ValueConverter<FirstName, string>
    {
        public FirstNameConversion() : base(m => m.Value, m => FirstName.FromString(m))
        {

        }
    }
}
