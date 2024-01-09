using brk.Framework.Base.Query;

namespace brk.Core.Domain.List.Query
{
    public class GetUserListDetail : IQueryResult<GetUserListDetailQuery>
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }

    public class GetUserListDetailQuery : IQuery
    {
        public long Id { get; set; }
    }
}
