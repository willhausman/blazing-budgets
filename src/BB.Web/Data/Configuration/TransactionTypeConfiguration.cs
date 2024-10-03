using BB.Web.Domain;
using BB.Web.Domain.Actuals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BB.Web.Data.Configuration;

public class TransactionTypeConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.Property(_ => _.Amount)
            .HasConversion(t => t.Value, v => new Money(v))
            .HasColumnName("amount")
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(_ => _.Category)
            .HasConversion(t => t.Value, v => new Category(v))
            .HasColumnName("category")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(_ => _.Note)
            .IsRequired(false);

        builder.Property(_ => _.Timestamp)
            .IsRowVersion()
            .HasColumnType("timestamp with time zone");
    }
}