using brk.Framework.Base.Query;

namespace brk.Core.Domain.TaskList.Query
{
    public class GetAllTasks:IQuery
    {
        public long ListId{ get; set; }
    }

    public class AllTaskData:IQueryResult<GetAllTasks>
    {
        public List<TaskData> Tasks { get; set; }
    }

    public class TaskData
    {

        public long TaskId { get; set; }
        public string Title { get; set; }
    }
}
