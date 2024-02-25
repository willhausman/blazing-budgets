namespace BB.Web.Domain.Actuals;

public record Transaction(Guid Id, DateOnly Date, Money Amount, Category Category, string Note);

public record TransactionPosted(DateOnly Date, Money Amount, Category Category, string Note);
