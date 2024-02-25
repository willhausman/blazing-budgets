namespace BB.Web.Domain;

public record Category(string Value, IReadOnlyCollection<Category> SubCategories)
{
    public readonly static Category All = new(nameof(All), []);
    public Category(string value) : this (value, []) { }

     public bool AppliesTo(Category category) =>
        this == Category.All || this == category || SubCategories.Any(_ => _.AppliesTo(category));
}
