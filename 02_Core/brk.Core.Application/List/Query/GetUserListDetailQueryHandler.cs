using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Query;
using brk.Framework.Base.Query;
using brk.Framework.Base.Web.Services;
using brk.Framework.Localization.List;

namespace brk.Core.Application.List.Query
{
    public class GetUserListDetailQueryHandler : BaseQueryHandler<GetUserListDetailQuery, GetUserListDetail>
    {
        private readonly IListQueryService _listQueryService;
        private readonly IUserInfoService _userInfoService;
        public GetUserListDetailQueryHandler(IListQueryService listQueryService, IUserInfoService userInfoService)
        {
            _listQueryService = listQueryService;
            _userInfoService = userInfoService;
        }

        public override async Task<OperationResult<GetUserListDetail>> HandleAsync(GetUserListDetailQuery query)
        {
            var userId=_userInfoService.GetUserId();
            var list = await _listQueryService.GetAsync(userId, query.Id);
            if (list is null)
                return Error(ListResource.NotFound);

            var result = new GetUserListDetail
            {
                Id = list.Id,
                Title = list.Title.Value
            };

            return Ok("",result);
        }
    }
}
