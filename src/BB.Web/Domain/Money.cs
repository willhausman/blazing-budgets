namespace BB.Web.Domain;

// To consider: need to worry about Currency?
public record Money(decimal Value)
{
    public static Money Zero { get; } = new(0);

    public Money FinalValue() => new(Value.RoundedToPrecision(2));

    public override string ToString() => $"$ {FinalValue().Value:F2}"; // Currency consideration.

    public int CompareTo(Money? other) => other is null ? 1 : Value.CompareTo(other.Value);

    public static Money operator +(Money lhs, Money rhs) => new(lhs.Value + rhs.Value);

    public static Money operator -(Money lhs, Money rhs) => new(lhs.Value - rhs.Value);
}

public static class MoneyExtensions
{
    public static decimal RoundedToPrecision(this decimal value, int precision) => Math.Round(value, precision, MidpointRounding.AwayFromZero);
}
