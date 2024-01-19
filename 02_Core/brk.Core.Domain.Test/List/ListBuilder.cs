using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.Test.List
{
    internal class ListBuilder
    {
        ListOwnerId ownerId = ListOwnerId.FromLong(3);
        Title title = Title.FromString("Title");

        public ListModel Build() => ListModel.Create(ownerId, title);
    }
}
