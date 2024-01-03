using brk.Framework.Base.Application;

namespace brk.Core.Domain.TaskList.Commands
{
    public class AddTaskCommand : ICommand
    {
        /// <summary>آیدی لیستی که تسک به آن اضافه شود </summary>
        public long ListId { get; set; }

        /// <summary>عنوان تسک </summary>
        public string Title { get; set; }
    }
}
