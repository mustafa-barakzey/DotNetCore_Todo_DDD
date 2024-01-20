using brk.Core.Application.User.Commands;
using brk.Core.Domain.User.Commands;
using brk.Core.Domain.User.Data;
using brk.Core.Domain.User.Entities;
using brk.Core.Domain.User.ValueObjects;
using brk.Framework.Base.ValueObjects;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace brk.Core.Application.Test.User.Commands
{
    public class LogInUserCommandHandlerTest
    {
        private readonly LogInUserCommandHandler _handler;
        private readonly IUserRepository _userRepository;
        public LogInUserCommandHandlerTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _handler = new LogInUserCommandHandler(_userRepository);
        }

        [Fact]
        public async Task handler_should_login_user()
        {
            var command = GetCommand();
            var userModel = UserModel.Create(FirstName.FromString("mustafa"), LastName.FromString("barakzey"), Email.FromString(command.Email), Password.FromString(command.Password));

            _userRepository.GetAsync(Email.FromString(command.Email),Password.FromString(command.Password)).Returns(userModel);
            await _handler.ExecuteAsync(command);
            await _userRepository.Received().GetAsync(Email.FromString(command.Email),Password.FromString(command.Password));
        
        }


        [Fact]
        public async Task handler_should_return_error_when_user_notfound()
        {
            var command = GetCommand();
            _userRepository.GetAsync(Email.FromString(command.Email), Password.FromString(command.Password)).ReturnsNull();
            await _handler.ExecuteAsync(command);
            await _userRepository.Received().GetAsync(Email.FromString(command.Email), Password.FromString(command.Password));
        }



        private LogInUserCommand GetCommand() => new LogInUserCommand
        {
            Email = "mustafabarakzey@gmail.com",
            Password = "my password"
        };
    }
}
