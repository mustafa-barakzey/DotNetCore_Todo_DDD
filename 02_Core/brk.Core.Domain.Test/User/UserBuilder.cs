using brk.Core.Domain.User.Entities;
using brk.Core.Domain.User.ValueObjects;
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.Test.User
{
    internal class UserBuilder
    {
        FirstName firstName = FirstName.FromString("mustafa");
        LastName lastName = LastName.FromString("barakzey");
        Password password = Password.FromString("Password");
        Email email = Email.FromString("mustafabarakzey@gmail.com");

        public UserBuilder() { }

        public UserModel Build()=>UserModel.Create(firstName,lastName,email,password);


    }
}
