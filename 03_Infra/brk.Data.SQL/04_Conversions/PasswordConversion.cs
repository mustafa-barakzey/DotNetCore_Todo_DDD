using brk.Core.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Infra.Data.Sql._04_Conversions
{
    internal class PasswordConversion : ValueConverter<Password, string>
    {
        public PasswordConversion() : base(m => m.Value, m => Password.FromString(m))
        {

        }
    }
}
