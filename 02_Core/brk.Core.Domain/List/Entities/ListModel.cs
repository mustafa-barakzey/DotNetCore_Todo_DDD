using brk.Core.Domain.List.ValueObjects;
using brk.Core.Domain.TaskList.Entities;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.List.Entities
{
    /// <summary>
    /// مدل لیست های کاربران که تسک ها در آن قرار میگیرد
    /// </summary>
    public class ListModel : AggregateRoot
    {
        #region properties

        /// <summary>صاحب لیست </summary>
        public long OwnerId { get; private set; }

        /// <summary>عنوان لیست </summary>
        public Title Title { get; private set; }

        /// <summary>موقعیت لیست</summary>
        public int Order { get; private set; }

        public IReadOnlyCollection<TaskModel> Tasks =>_tasks;
        private List<TaskModel> _tasks { get; set; } = new();

        #endregion

        private ListModel() { }
        private ListModel(ListOwnerId ownerId, Title title)
        {
            OwnerId = ownerId.Value;
            Title = title;
        }

        #region methods
        public static ListModel Create(ListOwnerId ownerId, Title title) => new(ownerId, title);

        public void SetOrder(int order)
        {
            Order = order;
        }

        public void AddTask(Title title)
        {
            _tasks.Add(TaskModel.Create(title));
        }

        public void Update(Title title)
        {
            Title = title;
        }

        #endregion
    }
}
