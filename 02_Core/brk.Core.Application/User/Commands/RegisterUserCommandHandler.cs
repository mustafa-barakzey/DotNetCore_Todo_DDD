using brk.Core.Domain.User.Commands;
using brk.Core.Domain.User.Data;
using brk.Core.Domain.User.Entities;
using brk.Framework.Localization.User;

namespace brk.Core.Application.User.Commands;

/// <summary>
/// اجرا کننده دستور ثبت نام کاربر
/// </summary>
public class RegisterUserCommandHandler : BaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _userRepository;
    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<OperationResult> ExecuteAsync(RegisterUserCommand command)
    {
        // چک کردن وجود اینکه کاربر از قبل وجود دارد یا خیر
        if (await _userRepository.IsExistAsync(Email.FromString(command.Email)))
            return Warning(UserResource.AlreadyExist);

        // ساخت کاربر جدید
        var user = UserModel.Create(
            FirstName.FromString(command.FirstName),
            LastName.FromString(command.LastName),
            Email.FromString(command.Email));

        await _userRepository.AddAsync(user);
        await _userRepository.CommitAsync();

        return Ok(UserResource.RegistrationIsDone);
    }
}
