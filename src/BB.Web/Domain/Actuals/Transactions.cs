using System.ComponentModel.DataAnnotations;

namespace BB.Web.Domain.Actuals;

public record TransactionPosted(DateOnly Date, Money Amount, Category Category, string Note);

public class Transaction(Guid id, DateOnly date, Money amount, Category category, string? note)
{
    public static Transaction Create(DateOnly date, Money amount, Category category, string? note = null) =>
        new(Guid.NewGuid(), date, amount, category, note);

    public Guid Id { get; private set; } = id;
    public DateOnly Date { get; private set; } = date;
    public Money Amount { get; private set; } = amount;
    public Category Category { get; private set; } = category;
    public string? Note { get; private set; } = note;
    public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.UtcNow;
}