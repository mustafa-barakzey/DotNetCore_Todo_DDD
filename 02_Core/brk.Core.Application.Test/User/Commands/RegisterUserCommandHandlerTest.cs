using brk.Core.Application.User.Commands;
using brk.Core.Domain.User.Commands;
using brk.Core.Domain.User.Data;
using brk.Framework.Base.Application;
using brk.Framework.Base.ValueObjects;
using NSubstitute;

namespace brk.Core.Application.Test.User.Commands
{
    public class RegisterUserCommandHandlerTest
    {
        private readonly RegisterUserCommandHandler _handler;
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandlerTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _handler = new RegisterUserCommandHandler(_userRepository);
        }

        [Fact]
        public async Task handler_should_register_user()
        {
            var command = GetCommand();

            _userRepository.IsExistAsync(Email.FromString(command.Email)).Returns(false);
            await _handler.ExecuteAsync(command);
            await _userRepository.Received().IsExistAsync(Email.FromString(command.Email));
            await _userRepository.ReceivedWithAnyArgs().AddAsync(default);
        }

        [Fact]
        public async Task handler_should_return_error_when_user_exist()
        {
            var command = GetCommand();
            _userRepository.IsExistAsync(Email.FromString(command.Email)).Returns(true);

            var result = await _handler.ExecuteAsync(command);
            await _userRepository.Received().IsExistAsync(Email.FromString(command.Email));
        }

        private RegisterUserCommand GetCommand()=> new RegisterUserCommand
        {
            FirstName = "mustafa",
            LastName = "barakzey",
            Email = "mustafabarakzey@gmail.com",
            Password = "my password"
        };
    }
}
