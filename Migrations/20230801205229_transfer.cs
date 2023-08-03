using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingProjectMVC.Migrations
{
    /// <inheritdoc />
    public partial class transfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChequeNumber",
                table: "Transfer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Depositor",
                table: "Transfer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepositorPhoneNo",
                table: "Transfer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChequeNumber",
                table: "Transfer");

            migrationBuilder.DropColumn(
                name: "Depositor",
                table: "Transfer");

            migrationBuilder.DropColumn(
                name: "DepositorPhoneNo",
                table: "Transfer");
        }
    }
}
