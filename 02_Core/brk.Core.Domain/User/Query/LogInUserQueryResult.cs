using brk.Framework.Base.Query;

namespace brk.Core.Domain.User.Query
{
    public class LogInUserQueryResult:IQueryResult
    {

        public LogInUserQueryResult(long id, string fullName)
        {
            UserId = id;
            FullName = fullName;
        }

        public long UserId { get; set; }

        public string FullName { get; set; }
    }
}
