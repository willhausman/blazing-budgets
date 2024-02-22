namespace BB.Web.Domain.Budgets;

public class Budget
{
    public Guid Id { get; set; }
    public BudgetSpan Span { get; set; }
}

public record struct BudgetSpan(DateOnly From, DateOnly To);
