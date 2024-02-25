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

    public override string ToString() => $"{From.ToShortDateString()} through {To.ToShortDateString()}";
}
