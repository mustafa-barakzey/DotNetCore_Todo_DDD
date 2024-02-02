using brk.Core.Application.List.Commands;
using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.ValueObjects;
using brk.Framework.Base.Web.Services;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace brk.Core.Application.Test.List.Commands
{
    public class EditListCommandHandlerTest
    {
        private readonly IListRepository _listRepository;
        private readonly IUserInfoService _userInfoService;
        private readonly EditListCommandHandler _handler;
        public EditListCommandHandlerTest()
        {
            _listRepository = Substitute.For<IListRepository>();
            _userInfoService = Substitute.For<IUserInfoService>();
            _handler = new EditListCommandHandler(_listRepository, _userInfoService);
        }

        [Fact]
        public async Task handler_should_edit_list()
        {
            var command = new EditListCommand
            {
                Id = 1,
                Title = "new list title"
            };
            var listModel = ListModel.Create(ListOwnerId.FromLong(5), Title.FromString("oldTitle"));
            _listRepository.GetByIdAsync(command.Id).Returns(listModel);

           var result = await _handler.ExecuteAsync(command);

            await _listRepository.Received().GetByIdAsync(command.Id);
            var newTitle = Title.FromString(command.Title);
            listModel.Update(newTitle);
            listModel.Title.Should().Be(newTitle);
            //result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task handler_should_return_error_when_list_notFound()
        {
            const long userId = 1;
            var command = new EditListCommand
            {
                Id = 1,
                Title = "new title"
            };
            var listModel = ListModel.Create(ListOwnerId.FromLong(1), Title.FromString("title"));
            _userInfoService.GetUserId().Returns(userId);
            _listRepository.GetByIdAsync(command.Id).ReturnsNull();

            listModel.Should().NotBeNull();
            listModel.OwnerId.Should().Be(userId);
            await _handler.ExecuteAsync(command);
        }


        [Fact]
        public async Task handler_should_return_error_when_user_isNot_owner()
        {
            const long userId = 1;
            var command = new EditListCommand
            {
                Id = 1,
                Title = "new title"
            };
            var listModel = ListModel.Create(ListOwnerId.FromLong(100), Title.FromString("title"));
            _userInfoService.GetUserId().Returns(1);
            _listRepository.GetByIdAsync(command.Id).Returns(listModel);

            listModel.Should().NotBeNull();
            listModel.OwnerId.Should().NotBe(userId);
            await _handler.ExecuteAsync(command);
        }
    }
}
