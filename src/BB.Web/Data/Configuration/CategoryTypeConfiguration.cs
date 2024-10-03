using BB.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BB.Web.Data.Configuration;

public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(_ => _.Value)
            .HasName("pk_category");
        builder.Property(_ => _.Value)
            .HasColumnName("category")
            .HasMaxLength(200);
        builder.HasMany(_ => _.SubCategories)
            .WithOne()
            .HasForeignKey("parent_category")
            .HasConstraintName("fk_parent_category");
    }
}