namespace brk.Framework.Tools.Pagination;

public class PaginationOption
{
    public const int DefaultPageSize = 12;
    public const int MaximumPageSize = 100;
    public const int DefaultPageIndex = 1;
    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int PageIndex { get; set; } = DefaultPageIndex;

    /// <summary>
    /// تعداد نمایش در صفحه
    /// </summary>
    public int PageSize { get; set; } = DefaultPageSize;
}