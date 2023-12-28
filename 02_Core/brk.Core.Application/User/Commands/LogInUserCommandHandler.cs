using brk.Core.Domain.User.Commands;
using brk.Core.Domain.User.Data;
using brk.Core.Domain.User.Query;
using brk.Core.Domain.User.ValueObjects;

namespace brk.Core.Application.User.Commands
{
    public class LogInUserCommandHandler : BaseCommandHandler<LogInUserCommand, LogInUserQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public LogInUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override async Task<OperationResult<LogInUserQueryResult>> ExecuteAsync(LogInUserCommand command)
        {
            var user = await _userRepository.GetAsync(Email.FromString(command.Email), Password.FromString(command.Password));
            if (user is null)
                return Error("کاربری با اطلاعات وارد شده یافت نشد");
            
            var result=new LogInUserQueryResult(user.Id,user.FullName);
            return Ok("",result);
        }
    }
}
