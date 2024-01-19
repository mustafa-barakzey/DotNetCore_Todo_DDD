using brk.Core.Domain.TaskList.Entities;
using brk.Framework.Base.ValueObjects;
using FluentAssertions;

namespace brk.Core.Domain.Test.TaskList.Entities
{
    public class TaskModelTest
    {
        [Fact]
        public void factory_should_create_new_task()
        {
            Title title= Title.FromString("task Title");
            var task = TaskModel.Create(title);

            task.Should().NotBeNull();
            task.Title.Should().Be(title);
            task.Status.Should().Be(Status.NotCompleted);
            task.Category.Should().Be(Category.None);
        }
    }
}
