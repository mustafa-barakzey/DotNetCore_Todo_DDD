using brk.Core.Domain.List.Data;
using brk.Core.Domain.TaskList.Query;
using brk.Framework.Base.Query;
using brk.Framework.Base.Web.Services;
using brk.Framework.Localization.List;

namespace brk.Core.Application.TaskList.Query
{
    public class GetAllTasksQueryHandler : BaseQueryHandler<GetAllTasks, AllTaskData>
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IListQueryService _listQueryService;
        public GetAllTasksQueryHandler(IUserInfoService userInfoService, IListQueryService listQueryService)
        {
            _userInfoService = userInfoService;
            _listQueryService = listQueryService;
        }

        public override async Task<OperationResult<AllTaskData>> HandleAsync(GetAllTasks query)
        {
            var userId=_userInfoService.GetUserId();
            var list = await _listQueryService.GetListAsync(userId, query.ListId);
            if (list == null)
                return Error(ListResource.NotFound);

            var result=list.Tasks.Select(m=>new TaskData { TaskId=m.Id,Title=m.Title.Value}).ToList();

            return Ok("", new() { Tasks = result });
        }
    }
}
