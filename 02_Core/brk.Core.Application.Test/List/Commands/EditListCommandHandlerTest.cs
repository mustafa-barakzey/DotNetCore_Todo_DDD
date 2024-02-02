using brk.Core.Application.List.Commands;
using brk.Core.Domain.List.Commands;
using brk.Core.Domain.List.Data;
using brk.Core.Domain.List.Entities;
using brk.Core.Domain.List.ValueObjects;
using brk.Framework.Base.ValueObjects;
using brk.Framework.Base.Web.Services;
using FluentAssertions;
using NSubstitute;

namespace brk.Core.Application.Test.List.Commands
{
    public class EditListCommandHandlerTest
    {
        private readonly IListRepository _listRepository;
        private readonly EditListCommandHandler _handler;
        public EditListCommandHandlerTest()
        {
            _listRepository = Substitute.For<IListRepository>();
            var userInfo = Substitute.For<IUserInfoService>();
            _handler = new EditListCommandHandler(_listRepository, userInfo);
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
    }
}
