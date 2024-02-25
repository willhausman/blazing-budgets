namespace BB.Web.Domain.Budgets;

public class Budget
{
    public Guid Id { get; set; }
    public required BudgetSpan Span { get; init; }

    public ICollection<BudgetLine> Lines { get; set; } = [];
}

public record BudgetSpan(DateOnly From, DateOnly To);


public record BudgetLine(DateOnly Date, Money Amount, Category Category, string Note);
