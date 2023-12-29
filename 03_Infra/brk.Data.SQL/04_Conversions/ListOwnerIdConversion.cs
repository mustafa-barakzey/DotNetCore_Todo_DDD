using brk.Core.Domain.List.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace brk.Data.SQL.List.Conversion
{
    internal class ListOwnerIdConversion : ValueConverter<ListOwnerId, long>
    {
        public ListOwnerIdConversion() : base(m => m.Value, id => ListOwnerId.FromLong(id))
        {

        }
    }
}
