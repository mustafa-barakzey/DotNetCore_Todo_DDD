using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.Web.Services;
using brk.Framework.Localization.List;

namespace brk.Core.Application.List.Commands
{
    public class AddListCommandHandler : BaseCommandHandler<AddListCommand>
    {
        private readonly IListRepository _listRepository;
        private readonly IUserInfoService _userInfoService;
        public AddListCommandHandler(IListRepository listRepository, IUserInfoService userInfoService)
        {
            _listRepository = listRepository;
            _userInfoService = userInfoService;
        }

        public override async Task<OperationResult> ExecuteAsync(AddListCommand command)
        {
            var userId = _userInfoService.GetUserId();
            if (await _listRepository.IsExistAsync(ListOwnerId.FromLong(userId), Title.FromString(command.Title)))
                return Info(ListResource.Already_Exist);

            var listModel = ListModel.Create(ListOwnerId.FromLong(userId), Title.FromString(command.Title));

            await _listRepository.AddAsync(listModel);
            await _listRepository.CommitAsync();
            return Ok(ListResource.SuccessfullyAdded);
        }
    }
}
