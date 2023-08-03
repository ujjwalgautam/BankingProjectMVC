using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class ModeRemoveInDeposit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldBalance",
                table: "Deposit");

            migrationBuilder.RenameColumn(
                name: "Mode",
                table: "Deposit",
                newName: "DepositorPhoneNo");

            migrationBuilder.AddColumn<string>(
                name: "Depositor",
                table: "Deposit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Depositor",
                table: "Deposit");

            migrationBuilder.RenameColumn(
                name: "DepositorPhoneNo",
                table: "Deposit",
                newName: "Mode");

            migrationBuilder.AddColumn<decimal>(
                name: "OldBalance",
                table: "Deposit",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
