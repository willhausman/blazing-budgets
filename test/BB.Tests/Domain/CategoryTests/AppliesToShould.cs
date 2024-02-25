using BB.Web.Domain;
using FluentAssertions;

namespace BB.Tests.Domain.CategoryTests;

public class AppliesToShould
{
    [Fact]
    public void MatchAllCategory()
    {
        var category = new Category("Random category");

        Category.All.AppliesTo(category).Should().BeTrue();
    }

    [Fact]
    public void MatchSameCategory()
    {
        var category = new Category("cat");

        category.AppliesTo(category with { }).Should().BeTrue();
    }

    [Fact]
    public void MatchSubcategory()
    {
        var child = new Category("child");
        var parent = new Category("parent", [child]);

        parent.AppliesTo(child).Should().BeTrue();
    }

    [Fact]
    public void NotMatchDifferentCategory()
    {
        var category = new Category("cat");
        var other = new Category("other");

        category.AppliesTo(other).Should().BeFalse();
    }
}
