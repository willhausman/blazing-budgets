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

        builder.HasOne(_ => _.Category)
            .WithMany()
            .HasForeignKey("category")
            .IsRequired()
            .HasPrincipalKey(_ => _.Value)
            .HasConstraintName("fk_transaction_category");

        builder.Navigation(_ => _.Category).IsRequired().AutoInclude();
        
        builder.Property(_ => _.Note)
            .IsRequired(false);
    }
}