namespace BB.Web.Domain;

public record Category(string Value, IReadOnlyCollection<Category> SubCategories)
{
    public static readonly Category All = new(nameof(All), []);
    public static Category Create(string value, Category[]? categories = null) => new(value, categories ?? []);

     public bool AppliesTo(Category category) =>
        Value == nameof(All) || Value == category.Value || SubCategories.Any(_ => _.AppliesTo(category));

     public override string ToString() => Value;
}
