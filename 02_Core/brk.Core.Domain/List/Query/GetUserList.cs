using brk.Framework.Base.Query;

namespace brk.Core.Domain.List.Query
{
    public class GetUserList:IQueryResult
    {
        public List<UserList> List { get; set; }
    }

    public class UserList
    {
        public UserList(long id, string title)
        {
            Id = id;
            Title = title;
        }

        public long Id { get; set; }
        public string Title { get; set; }
    }
}
