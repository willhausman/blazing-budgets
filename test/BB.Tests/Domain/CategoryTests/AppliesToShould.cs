using BB.Web.Domain;
using FluentAssertions;

namespace BB.Tests.Domain.CategoryTests;

public class AppliesToShould
{
    [Fact]
    public void MatchAllCategory()
    {
        var category = Category.Create("Random category");

        Category.All.AppliesTo(category).Should().BeTrue();
    }

    [Fact]
    public void MatchSameCategory()
    {
        var category = Category.Create("cat");

        category.AppliesTo(category with { }).Should().BeTrue();
    }

    [Fact]
    public void MatchSubcategory()
    {
        var child = Category.Create("child");
        var parent = Category.Create("parent", [child]);

        parent.AppliesTo(child).Should().BeTrue();
    }

    [Fact]
    public void NotMatchDifferentCategory()
    {
        var category = Category.Create("cat");
        var other = Category.Create("other");

        category.AppliesTo(other).Should().BeFalse();
    }
}
