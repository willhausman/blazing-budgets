using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                    insert into categories(category, parent_category)
                                    values
                                        ('Food', null),
                                        ('Groceries', 'Food'),
                                        ('Dining Out', 'Food'),
                                        ('Cars', null),
                                        ('Gasoline', 'Cars')
                                    ;
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from categories");
        }
    }
}