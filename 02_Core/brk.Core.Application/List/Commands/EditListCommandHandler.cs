using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Data;
using brk.Framework.Base.Web.Services;
using brk.Framework.Localization.List;

namespace brk.Core.Application.List.Commands
{
    public class EditListCommandHandler : BaseCommandHandler<EditListCommand>
    {
        private readonly IListRepository _listRepository;
        private readonly IUserInfoService _userInfoService;

        public EditListCommandHandler(IListRepository listRepository, IUserInfoService userInfoService)
        {
            _listRepository = listRepository;
            _userInfoService = userInfoService;
        }

        public override async Task<OperationResult> ExecuteAsync(EditListCommand command)
        {
            var userId = _userInfoService.GetUserId();
            var list=await _listRepository.GetByIdAsync(command.Id);
            if (list is null || list.OwnerId != userId)
                return Error(ListResource.NotFound);

            list.Update(Title.FromString(command.Title));
            await _listRepository.CommitAsync();
            return Ok(ListResource.SuccessfullyEdited);
        }
    }
}
