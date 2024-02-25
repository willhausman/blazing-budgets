namespace BB.Web.Domain;

// To consider: need to worry about Currency?
public readonly record struct Money(decimal Value)
{
    public static Money Zero { get; } = new(0);

    public readonly Money Finalize() => new(Value.RoundedToPrecision(2));

    public override readonly string ToString() => $"$ {Finalize().Value:F2}"; // Currency consideration.

    public readonly int CompareTo(Money? other) => other is null ? 1 : Value.CompareTo(other.Value);

    public static Money operator +(Money lhs, Money rhs) => new(lhs.Value + rhs.Value);

    public static Money operator -(Money lhs, Money rhs) => new(lhs.Value - rhs.Value);
}

public static class MoneyExtensions
{
    public static decimal RoundedToPrecision(this decimal value, int precision) => Math.Round(value, precision, MidpointRounding.AwayFromZero);
}