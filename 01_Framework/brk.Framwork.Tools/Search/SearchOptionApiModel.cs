namespace brk.Framework.Tools.Search;

/// <summary>
/// فیلتر بر اساس ستون های جداول دیتابیسی
/// </summary>
public class SearchOptionApiModel
{
    /// <summary>
    /// ستون مورد نظر برای جستجو
    /// </summary>
    public string? SearchKey { get; set; }

    /// <summary>
    /// کلمه جستجو شده
    /// </summary>
    public string? Search { get; set; }
}

public class SearchableProprty
{
    public string Key { get; set; }
    public string Name { get; set; }
}