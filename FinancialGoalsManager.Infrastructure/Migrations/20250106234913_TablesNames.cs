using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialGoalsManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Financial_Transactions_Financial_Goal_FinancialGoalId",
                table: "Financial_Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Financial_Transactions",
                table: "Financial_Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Financial_Goal",
                table: "Financial_Goal");

            migrationBuilder.RenameTable(
                name: "Financial_Transactions",
                newName: "FinancialGoalTransactions");

            migrationBuilder.RenameTable(
                name: "Financial_Goal",
                newName: "FinancialGoals");

            migrationBuilder.RenameIndex(
                name: "IX_Financial_Transactions_FinancialGoalId",
                table: "FinancialGoalTransactions",
                newName: "IX_FinancialGoalTransactions_FinancialGoalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialGoalTransactions",
                table: "FinancialGoalTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialGoals",
                table: "FinancialGoals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialGoalTransactions_FinancialGoals_FinancialGoalId",
                table: "FinancialGoalTransactions",
                column: "FinancialGoalId",
                principalTable: "FinancialGoals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialGoalTransactions_FinancialGoals_FinancialGoalId",
                table: "FinancialGoalTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialGoalTransactions",
                table: "FinancialGoalTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialGoals",
                table: "FinancialGoals");

            migrationBuilder.RenameTable(
                name: "FinancialGoalTransactions",
                newName: "Financial_Transactions");

            migrationBuilder.RenameTable(
                name: "FinancialGoals",
                newName: "Financial_Goal");

            migrationBuilder.RenameIndex(
                name: "IX_FinancialGoalTransactions_FinancialGoalId",
                table: "Financial_Transactions",
                newName: "IX_Financial_Transactions_FinancialGoalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Financial_Transactions",
                table: "Financial_Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Financial_Goal",
                table: "Financial_Goal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Financial_Transactions_Financial_Goal_FinancialGoalId",
                table: "Financial_Transactions",
                column: "FinancialGoalId",
                principalTable: "Financial_Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
