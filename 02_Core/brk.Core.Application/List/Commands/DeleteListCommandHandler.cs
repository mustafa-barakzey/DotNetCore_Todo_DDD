using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Data;
using brk.Framework.Base.Web.Services;
using brk.Framework.Localization.List;

namespace brk.Core.Application.List.Commands
{
    public class DeleteListCommandHandler : BaseCommandHandler<DeleteListCommand>
    {
        private readonly IListRepository _listRepository;
        private readonly IUserInfoService _userInfoService;
        public DeleteListCommandHandler(IListRepository listRepository, IUserInfoService userInfoService)
        {
            _listRepository = listRepository;
            _userInfoService = userInfoService;
        }

        public override async Task<OperationResult> ExecuteAsync(DeleteListCommand command)
        {
            var userId = _userInfoService.GetUserId();
            var list = await _listRepository.GetGraphAsync(command.Id);
            if (list is null || list.OwnerId != userId)
                return Error(ListResource.NotFound);

            await _listRepository.DeleteAsync(list);
            await _listRepository.CommitAsync();
            return Ok(ListResource.SuccessfullyDeleted);
        }
    }
}
