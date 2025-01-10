using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialGoalsManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SavedValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SavedValue",
                table: "FinancialGoals",
                type: "float(10)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SavedValue",
                table: "FinancialGoals");
        }
    }
}
