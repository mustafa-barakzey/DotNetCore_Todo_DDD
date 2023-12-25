using System.Collections;

namespace brk.Framework.Tools.Pagination;

public abstract class Paginated: PaginationOption
{
    public int ItemsCount { get; private set; }
    public int TotalPage { get; private set; }

    protected Paginated(int itemsCount, int pageSize, int pageIndex)
    {
        PageSize = pageSize <= 0 ? DefaultPageSize : pageSize > MaximumPageSize ? MaximumPageSize : pageSize;

        TotalPage = (int)Math.Ceiling(ItemsCount / (double)PageSize);

        if (TotalPage == 0)
            TotalPage = 1;

        if (pageIndex > TotalPage)
            PageIndex = TotalPage;

        ItemsCount = itemsCount;
    }

}
//public class Paginated<T, U> : Paginated where T : List<U>
//{
//    public List<U> Items { get; private set; }

//    public Paginated(List<U> items, int pageSize, int pageIndex) : base(items.Count(), pageSize, pageIndex)
//    {
//        Items = items;
//    }
//}

public class Paginated<U> : Paginated 
{
    public IQueryable<U> Items { get; private set; }

    public Paginated(IQueryable<U> items, int pageSize, int pageIndex) :base(items.Count(),pageSize,pageIndex)
    {
        Items = items;
    }
}