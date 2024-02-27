using Marten.Events;

namespace BB.Web.Domain.Actuals;

public class Ledger
{
    public required Category Category { get; init; }
    public required DateSpan Span { get; init; }
    public IList<Transaction> Transactions { get; } = [];
    public Money Balance { get; private set; } = Money.Zero;

    public void Apply(IEvent<TransactionPosted> @event)
    {
        if (Category.AppliesTo(@event.Data.Category))
        {
            Transactions.Add(new(@event.Id, @event.Data.Date, @event.Data.Amount, @event.Data.Category, @event.Data.Note));
            Balance += @event.Data.Amount;
        }
    }
}
