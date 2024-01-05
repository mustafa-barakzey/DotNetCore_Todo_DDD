using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Data;
using brk.Framework.Localization.List;

namespace brk.Core.Application.List.Commands
{
    public class EditListCommandHandler : BaseCommandHandler<EditListCommand>
    {
        private readonly IListRepository _listRepository;

        public EditListCommandHandler(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }

        public override async Task<OperationResult> ExecuteAsync(EditListCommand command)
        {
            var list=await _listRepository.GetByIdAsync(command.Id);
            if (list is null)
                return Error(ListResource.NotFound);

            list.Update(Title.FromString(command.Title));
            await _listRepository.CommitAsync();
            return Ok(ListResource.SuccessfullyEdited);
        }
    }
}
