namespace BB.Web.Domain;

public record DateSpan
{
    public DateOnly From { get; }
    public DateOnly To { get; }

    public DateSpan(DateOnly from, DateOnly to)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(from, to);
        From = from;
        To = to;
    }

    public bool Contains(DateTime dateTime)
    {
        var date = DateOnly.FromDateTime(dateTime);

        return date >= From && date <= To;
    }

    public bool Contains(DateOnly date)
    {
        return date >= From && date <= To;
    }

    public override string ToString() => $"{From.ToString("O")} through {To.ToString("O")}";
}
