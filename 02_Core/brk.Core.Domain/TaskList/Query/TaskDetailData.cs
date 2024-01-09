using brk.Framework.Base.Query;

namespace brk.Core.Domain.TaskList.Query
{
    public class GetTaskDetail:IQuery
    {
        public long ListId{ get; set; }
        public long TaskId { get; set; }
    }

    public class TaskDetailData:IQueryResult<GetTaskDetail>
    {
        public long TaskId { get; set;}
        public string Title { get; set; }
    }
}
