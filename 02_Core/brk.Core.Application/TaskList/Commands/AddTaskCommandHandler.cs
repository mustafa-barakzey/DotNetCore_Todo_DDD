using brk.Core.Domain.List.Data;
using brk.Core.Domain.TaskList.Commands;
using brk.Framework.Base.Web.Services;

namespace brk.Core.Application.TaskList.Commands
{
    public class AddTaskCommandHandler : BaseCommandHandler<AddTaskCommand>
    {
        private readonly IListRepository _listRepository;
        private readonly IUserInfoService _userInfoService;

        public AddTaskCommandHandler(IListRepository listRepository, IUserInfoService userInfoService)
        {
            _listRepository = listRepository;
            _userInfoService = userInfoService;
        }

        public override async Task<OperationResult> ExecuteAsync(AddTaskCommand command)
        {
            var userId = _userInfoService.GetUserId();

            var list = await _listRepository.GetGraphAsync(m=>m.OwnerId== userId && m.Id == command.ListId);
            if (list == null)
                return Error("لیست یافت نشد");

            list.AddTask(Title.FromString(command.Title));
            await _listRepository.CommitAsync();

            return Ok("");
        }
    }
}
