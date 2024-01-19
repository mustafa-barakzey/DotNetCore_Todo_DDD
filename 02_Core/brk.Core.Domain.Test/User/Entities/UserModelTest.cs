using brk.Core.Domain.User.Entities;
using brk.Core.Domain.User.ValueObjects;
using brk.Framework.Base.ValueObjects;
using FluentAssertions;

namespace brk.Core.Domain.Test.User.Entities
{
    public class UserModelTest
    {
        private readonly UserBuilder _userBuilder;
        public UserModelTest()
        {
            _userBuilder = new UserBuilder();
        }

        [Fact]
        public void factory_should_create_new_user()
        {
            FirstName firstName = FirstName.FromString("mustafa");
            LastName lastName = LastName.FromString("barakzey");
            Password password = Password.FromString("Password");
            Email email = Email.FromString("mustafabarakzey@gmail.com");

            var userModel = UserModel.Create(firstName, lastName, email, password);
            
            userModel.Should().NotBeNull();
            userModel.FirstName.Should().Be(firstName);
            userModel.LastName.Should().Be(lastName);
            userModel.Email.Should().Be(email);
            userModel.Password.Should().Be(password);
        }

        [Fact]
        public void set_password_should_update_password()
        {
            var userModel = _userBuilder.Build();
            var newPassword=Password.FromString("newPassword");
            userModel.SetPassword(newPassword);
            userModel.Password.Should().Be(newPassword);
        }
    }
}
