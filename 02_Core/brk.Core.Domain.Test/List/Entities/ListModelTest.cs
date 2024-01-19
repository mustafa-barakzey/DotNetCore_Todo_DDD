using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.ValueObjects;
using FluentAssertions;

namespace brk.Core.Domain.Test.List.Entities
{
    public class ListModelTest
    {
        private readonly ListBuilder _listBuilder;
        public ListModelTest()
        {
            _listBuilder = new ListBuilder();
        }

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

        [Fact]
        public void set_order_should_update_list_order()
        {
            var model = _listBuilder.Build();

            const int order = 100;
            model.SetOrder(order);
            model.Order.Should().Be(order);
        }

        [Fact]
        public void update_should_update_list_title()
        {
            var model = _listBuilder.Build();

            var title = Title.FromString("new Title");

            model.Update(title);
            model.Title.Should().Be(title);
        }

        [Fact]
        public void add_task_should_add_new_task_to_list()
        {
            var list = _listBuilder.Build();

            var taskTitle = Title.FromString("task title");

            list.AddTask(taskTitle);

            list.Tasks.Should().Contain(m=>m.Title == taskTitle);
        }
    }
}
