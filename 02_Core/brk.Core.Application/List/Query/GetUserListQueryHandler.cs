using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Query;
using brk.Framework.Base.Query;
using brk.Framework.Base.Web.Services;

namespace brk.Core.Application.List.Query
{
    public class GetUserListQueryHandler : BaseQueryHandler<GetUserList>
    {
        private readonly IListQueryService _queryService;
        private readonly IUserInfoService _userInfoService;
        public GetUserListQueryHandler(IListQueryService queryService, IUserInfoService userInfoService)
        {
            _queryService = queryService;
            _userInfoService = userInfoService;
        }

        public override async Task<OperationResult<GetUserList>> HandleAsync()
        {
            var userId = _userInfoService.GetUserId();
            var list = await _queryService.GetByUserIdAsync(userId);

            var result = new GetUserList
            {
                List = list.Select(m => new UserList(m.Id, m.Title.Value)).ToList(),
            };

            return Ok("", result);
        }
    }
}
