using BB.Web.Domain.Actuals;

namespace BB.Web.Domain;

public record Category(string Value, IReadOnlyCollection<Category> SubCategories)
{
    public readonly static Category All = new(nameof(All), []);
    public Category(string value) : this (value, []) { }

     public bool AppliesTo(Transaction transaction) =>
        this == Category.All || this == transaction.Category;    
}
