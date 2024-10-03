using BB.Web.Data.Configuration;
using BB.Web.Domain;
using BB.Web.Domain.Actuals;
using Microsoft.EntityFrameworkCore;

namespace BB.Web.Data;

public class BlazingContext(DbContextOptions<BlazingContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionTypeConfiguration());
        
        ConvertModelsToSnakeCase(modelBuilder);
    }

    // Postgres is case-sensitive. I don't want to wrap any of my manual queries with " like select "Id" from "Transactions" where "Category"='Food'. Yuck.
    private static void ConvertModelsToSnakeCase(ModelBuilder modelBuilder)
    {
        // Make all table names lowercase
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(ToSnakeCase(entity.GetTableName()!));
            foreach (var property in entity.GetProperties())
                property.SetColumnName(ToSnakeCase(property.GetColumnName()));
            foreach (var key in entity.GetKeys())
                key.SetName(ToSnakeCase(key.GetName()!));
            foreach (var foreignKey in entity.GetForeignKeys())
                foreignKey.SetConstraintName(ToSnakeCase(foreignKey.GetConstraintName()!));
            foreach (var index in entity.GetIndexes())
                index.SetDatabaseName(ToSnakeCase(index.GetDatabaseName()!));
        }
    }
    
    private static string ToSnakeCase(string input)
    {
        return string.Concat(
            input.Select((x, i) =>
                i > 0 && char.IsUpper(x) 
                    ? "_" + x.ToString() 
                    : x.ToString())).ToLower();
    }
}
