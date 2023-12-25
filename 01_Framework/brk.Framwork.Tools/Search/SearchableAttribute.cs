namespace brk.Framework.Tools.Search
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SearchableAttribute : Attribute
    {
        public string Name { get; set; }
        public SearchableAttribute() { }
    }
}
