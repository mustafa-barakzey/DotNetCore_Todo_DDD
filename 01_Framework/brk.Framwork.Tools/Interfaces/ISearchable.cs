using brk.Framework.Tools.Search;

namespace brk.Framework.Tools.Interfaces
{
    public interface ISearchable
    {
        public List<SearchableProprty> SearchOptions { get; set; }
    }

    public abstract class Searchable<T>
    {
        public List<SearchableProprty> SearchOptions => SearchHelper.GetSearchablePropertis<T>().AsSearchProperty();
    }
}
