
using brk.Framework.Base.ValueObjects;

namespace brk.Core.Domain.User.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class UserModel : AggregateRoot<long>
    {
        #region constructor

        private UserModel() { }

        private UserModel(FirstName firstName, LastName lastName, Email email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }


        #endregion

        #region properties

        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public Mobile? Mobile { get; private set; }

        #endregion

        #region methods

        public static UserModel Create(FirstName firstName, LastName lastName, Email email) => new(firstName, lastName, email);

        public void SetMobile(Mobile mobile)
        {
            Mobile = mobile;
        }

        #endregion
    }
}

