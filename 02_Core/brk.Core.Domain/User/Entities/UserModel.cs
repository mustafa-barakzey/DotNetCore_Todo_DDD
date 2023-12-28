
using brk.Core.Domain.User.ValueObjects;
using brk.Framework.Base.ValueObjects;
using brk.Framework.Tools.Utils;

namespace brk.Core.Domain.User.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class UserModel : AggregateRoot<long>
    {
        #region constructor

        private UserModel() { }

        private UserModel(FirstName firstName, LastName lastName, Email email, Password password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }


        #endregion

        #region properties

        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public Email Email { get; private set; }

        public Mobile? Mobile { get; private set; }

        public Password? Password { get;private set; }

        public string? SecurityStamp { get;private set; }

        public string FullName => FirstName + " " + LastName;

        #endregion

        #region methods

        public static UserModel Create(FirstName firstName, LastName lastName, Email email, Password password) => new(firstName, lastName, email,password);

        public void SetMobile(Mobile mobile)
        {
            Mobile = mobile;
        }

        public void SetPassword(Password password)
        {
            Password = password;
            SecurityStamp = Helper.GenerateToken();
        }

        #endregion
    }
}

