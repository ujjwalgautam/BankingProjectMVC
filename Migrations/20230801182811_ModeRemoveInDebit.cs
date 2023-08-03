using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class ModeRemoveInDebit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Debit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mode",
                table: "Debit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
