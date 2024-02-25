
using BB.Web.Domain;
using FluentAssertions;

namespace BB.Tests.Domain.DateSpanTests;

public class ContainsShould
{
    [Fact]
    public void FindDatesWithinTheRange()
    {
        given_a_datespan()
        .and
        .given_a_date_to_check()

        .when_datespan_checks_the_date()
        
        .then_the_date_should_be_found_in_the_range()
        ;
    }

    [Fact]
    public void FindDatesAtTheBeginning()
    {
        given_a_datespan()
        .and
        .given_a_date_at_the_beginning_of_the_datespan()

        .when_datespan_checks_the_date()

        .then_the_date_should_be_found_in_the_range()
        ;
    }

    [Fact]
    public void FindDatesAtTheEnd()
    {
        given_a_datespan()
        .and
        .given_a_date_at_the_end_of_the_datespan()

        .when_datespan_checks_the_date()

        .then_the_date_should_be_found_in_the_range()
        ;
    }

    private bool? result;
    private DateTime? dateTime;
    private DateSpan? target;
    private readonly DateOnly today = DateOnly.FromDateTime(DateTime.Now);

    private ContainsShould and => this;

    private ContainsShould given_a_date_to_check()
    {
        dateTime = DateTime.Now;
        return this;
    }

    private ContainsShould given_a_datespan()
    {
        target = new DateSpan(today.AddDays(-1), today.AddDays(1));
        return this;
    }

    private ContainsShould given_a_date_at_the_beginning_of_the_datespan()
    {
        dateTime = new DateTime(target?.From ?? DateOnly.MinValue, TimeOnly.MinValue);
        return this;
    }

        private ContainsShould given_a_date_at_the_end_of_the_datespan()
    {
        dateTime = new DateTime(target?.To ?? DateOnly.MaxValue, TimeOnly.MinValue);
        return this;
    }

    private ContainsShould when_datespan_checks_the_date()
    {
        result = target?.Contains(dateTime.HasValue ? dateTime.Value : DateTime.MinValue);
        return this;
    }

    private ContainsShould then_the_date_should_be_found_in_the_range()
    {
        result.Should().BeTrue();
        return this;
    }
}
