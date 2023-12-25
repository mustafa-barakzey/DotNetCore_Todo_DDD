using brk.Framework.Tools.Utils;
using System.Reflection;

namespace brk.Framework.Tools.Search;

public class SearchHelper
{
    private List<PropertyInfo> _propertyInfos;
    private List<SearchableProprty> _searchableProprties;
    private SearchHelper(List<PropertyInfo> searchableProperties)
    {
        _propertyInfos = searchableProperties;
    }

    public static SearchHelper GetSearchablePropertis<T,TU>()
    {
        var props = AttributeHelper.GetPropertiesByAttribute<T, SearchableAttribute>();
        var props2 = AttributeHelper.GetPropertiesByAttribute<TU, SearchableAttribute>();
        props.AddRange(props2);
        return new(props);
    }
    public static SearchHelper GetSearchablePropertis<T>()
    {
        return new(AttributeHelper.GetPropertiesByAttribute<T, SearchableAttribute>());
    }

    public List<SearchableProprty> AsSearchProperty(bool onlyHasName = true)
    {
        _searchableProprties = _propertyInfos.Select(m => new SearchableProprty()
        {
            Key = m.Name,
            Name = m.GetCustomAttribute<SearchableAttribute>()?.Name ?? ""
        }).Where(m => !onlyHasName || !string.IsNullOrWhiteSpace(m.Name)).ToList();
        return _searchableProprties;
    }

    public SearchHelper Properties(params string[] propertyNames)
    {
        _propertyInfos = _propertyInfos.Where(m => propertyNames.Contains(m.Name)).ToList();
        return this;
    }
    public SearchHelper RemoveItems(params string[] propertyNames)
    {
        _propertyInfos = _propertyInfos.Where(m => !propertyNames.Contains(m.Name)).ToList();
        return this;
    }
}