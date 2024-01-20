using brk.Core.Application.List.Commands;
using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.ValueObjects;
using brk.Framework.Base.Web.Services;
using NSubstitute;

namespace brk.Core.Application.Test.List.Commands
{
    public class AddListCommandHandlerTest
    {
        private readonly IListRepository _listRepository;
        private readonly AddListCommandHandler _handler;
        public AddListCommandHandlerTest()
        {
            _listRepository = Substitute.For<IListRepository>();
            var userInfo = Substitute.For<IUserInfoService>();
            _handler = new AddListCommandHandler(_listRepository, userInfo);
        }

        [Fact]
        public async Task handler_should_add_new_list()
        {
            var command = new AddListCommand
            {
                Title = "list title"
            };

            var ownerId = ListOwnerId.FromLong(100);
            var title = Title.FromString(command.Title);
            _listRepository.IsExistAsync(ownerId, title).Returns(false);

            await _handler.ExecuteAsync(command);
            await _listRepository.ReceivedWithAnyArgs().AddAsync(Arg.Any<ListModel>());
            //await _listRepository.Received().CommitAsync();
        }

        [Fact]
        public async Task handler_should_return_error_when_list_exist()
        {
            var command = new AddListCommand
            {
                Title = "list title"
            };

            var ownerId = ListOwnerId.FromLong(100);
            var title = Title.FromString(command.Title);
            _listRepository.IsExistAsync(ownerId, title).Returns(false);

            await _handler.ExecuteAsync(command);
        }
    }
}
