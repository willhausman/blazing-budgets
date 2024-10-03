namespace BB.Web.Domain;

public record Category(string Value)
{
    public IReadOnlyCollection<Category> SubCategories { get; init; } = [];
    public static readonly Category All = new(nameof(All));
    public static Category Create(string value, Category[]? categories = null) => new(value) { SubCategories = categories ?? [] };

     public bool AppliesTo(Category category) =>
        Value == nameof(All) || Value == category.Value || SubCategories.Any(_ => _.AppliesTo(category));

     public override string ToString() => Value;
}
