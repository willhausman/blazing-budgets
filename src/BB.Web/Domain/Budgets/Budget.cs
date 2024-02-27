namespace BB.Web.Domain.Budgets;

public class Budget
{
    public Guid Id { get; set; }
    public required DateSpan Span { get; init; }

    public ICollection<BudgetLine> Lines { get; set; } = [];
}

// TODO: Future/recurring budget lines
public record BudgetLine(Money Amount, Category Category, string Note);
