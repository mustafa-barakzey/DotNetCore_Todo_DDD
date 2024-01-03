using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.TaskList.Entities
{
    public class TaskModel : Entity
    {
        #region properties

        public long ListId { get; private set; }

        public Title Title { get; private set; }

        public Description? Description { get; private set; }

        public Category Category { get; private set; }

        public int Order { get; private set; }

        public Status Status { get; private set; }

        #endregion

        private TaskModel() { }
        private TaskModel(Title title)
        {
            Title = title;
            Status = Status.NotCompleted;
            Category = Category.None;
        }

        public static TaskModel Create(Title title) => new(title);
    }
}
