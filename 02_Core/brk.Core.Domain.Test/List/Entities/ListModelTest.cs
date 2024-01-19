using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.ValueObjects;
using FluentAssertions;

namespace brk.Core.Domain.Test.List.Entities
{
    public class ListModelTest
    {
        [Fact]
        public void factory_should_create_new_list()
        {
            var ownerId=ListOwnerId.FromLong(3);
            var title=Title.FromString("Title");
            var model = ListModel.Create(ownerId, title);

            model.Should().NotBeNull();
            model.OwnerId.Should().Be(ownerId.Value);
            model.Title.Should().Be(title);
        }

    }
}
