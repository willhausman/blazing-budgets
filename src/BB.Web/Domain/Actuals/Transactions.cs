namespace BB.Web.Domain.Actuals;

public record Transaction(Guid Id, DateOnly Date, Money Amount, Category Category, string Note);

public record TransactionPosted(Transaction Transaction);

public class Ledger
{
    public required Category Category { get; init; }

    public IList<Transaction> Transactions { get; } = [];

    public void Apply(TransactionPosted @event)
    {
        if (Category.AppliesTo(@event.Transaction))
        {
            Transactions.Add(@event.Transaction);
        }
    }
}

public static class TransactionExtensions
{
    public static bool AppliesTo(this Category category, Transaction transaction) =>
        category == Category.All || category == transaction.Category;    
}
