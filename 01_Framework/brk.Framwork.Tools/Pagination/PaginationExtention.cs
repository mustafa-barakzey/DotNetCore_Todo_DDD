namespace brk.Framework.Tools.Pagination
{
    public static class PaginationExtention
    {
        //public static Paginated<List<T>, T> ApplyPagination<T>(this List<T> source,
        //    PaginationOption option)
        //{
        //    ValidatePagintaionOption(option);
        //    return new Paginated<List<T>,T>(source, option.PageSize, option.PageIndex);
        //}
        public static Paginated<T> ApplyPagination<T>(this IQueryable<T> source, PaginationOption option)
        {
            ValidatePagintaionOption(option);
            return new Paginated<T>(source, option.PageSize, option.PageIndex);
        }

        private static void ValidatePagintaionOption(PaginationOption option)
        {
            option.PageIndex = option.PageIndex <= 0 ? PaginationOption.DefaultPageIndex : option.PageIndex;
            option.PageSize = option.PageSize <= 0 ? PaginationOption.DefaultPageSize : option.PageSize;
        }
    }
}
