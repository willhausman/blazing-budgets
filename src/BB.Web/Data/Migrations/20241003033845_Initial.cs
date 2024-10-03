using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BB.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    category = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    parent_category = table.Column<string>(type: "character varying(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_category", x => x.category);
                    table.ForeignKey(
                        name: "fk_parent_category",
                        column: x => x.parent_category,
                        principalTable: "categories",
                        principalColumn: "category");
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    category = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", rowVersion: true, nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transactions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_parent_category",
                table: "categories",
                column: "parent_category");

            migrationBuilder.AddForeignKey(
                name: "fk_transaction_category",
                table: "transactions",
                column: "category",
                principalTable: "categories",
                principalColumn: "category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}
