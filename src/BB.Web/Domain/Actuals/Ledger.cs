using Marten;
using Marten.Events;
using Marten.Events.Projections;

namespace BB.Web.Domain.Actuals;

public record Ledger(string Id, DateSpan Span, Category Category)
{
    public IList<Transaction> Transactions { get; init; } = [];
    public Money Balance { get; init; } = Money.Zero;

    public Ledger Apply(IEvent<TransactionPosted> @event)
    {
        if (Category.AppliesTo(@event.Data.Category) && Span.Contains(@event.Data.Date))
        {
            var balance = Balance + @event.Data.Amount;

            return this with
            {
                Transactions =
                [
                    ..Transactions,
                    new Transaction(@event.Id, @event.Data.Date, @event.Data.Amount, @event.Data.Category, @event.Data.Note),
                ],
                Balance = Balance + @event.Data.Amount,
            };
        }

        return this;
    }
}

public record LedgerCreated(Category Category, DateSpan Span);

public class LedgerProjection : EventProjection
{
    public LedgerProjection()
    {
        Project<LedgerCreated>((e, ops) =>
            ops.Store(new Ledger(e.Span.ToString(), e.Span, e.Category)));
    }

    public async Task Project(IEvent<TransactionPosted> e, IDocumentOperations ops)
    {
        var ledgers = await ops.Query<Ledger>().Where(_ => _.Span.From <= e.Data.Date && _.Span.To >= e.Data.Date).ToListAsync();
        ops.Store(ledgers.Where(_ => _.Category.AppliesTo(e.Data.Category)).Select(_ => _.Apply(e)));
    }
}