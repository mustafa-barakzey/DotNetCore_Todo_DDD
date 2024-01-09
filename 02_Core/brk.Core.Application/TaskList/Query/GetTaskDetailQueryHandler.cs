using brk.Core.Domain.List.Data;
using brk.Core.Domain.TaskList.Query;
using brk.Framework.Base.Query;
using brk.Framework.Base.Web.Services;
using brk.Framework.Localization.List;

namespace brk.Core.Application.TaskList.Query
{
    public class GetTaskDetailQueryHandler : BaseQueryHandler<GetTaskDetail, TaskDetailData>
    {
        private readonly IListQueryService _listQueryService;
        private readonly IUserInfoService _userInfoService;
        public GetTaskDetailQueryHandler(IListQueryService listRepository, IUserInfoService userInfoService)
        {
            _listQueryService = listRepository;
            _userInfoService = userInfoService;
        }

        public override async Task<OperationResult<TaskDetailData>> HandleAsync(GetTaskDetail query)
        {
            var userId = _userInfoService.GetUserId();
            var list = await _listQueryService.GetListAsync(userId, query.ListId);
            if (list is null)
                return Error(ListResource.NotFound);
            var task = list.Tasks.FirstOrDefault(m => m.Id == query.TaskId);
            if (task is null) return Error(ListResource.TaskNotFound);

            var result = new TaskDetailData()
            {
                TaskId = query.TaskId,
                Title = task.Title.Value
            };

            return Ok("", result);
        }
    }
}
