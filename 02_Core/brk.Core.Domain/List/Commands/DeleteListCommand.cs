using brk.Framework.Base.Application;

namespace brk.Core.Domain.List.Commands
{
    public class DeleteListCommand : ICommand
    {
        public long Id { get; set; }
    }
}
