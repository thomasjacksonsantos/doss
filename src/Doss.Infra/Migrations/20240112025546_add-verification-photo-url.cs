using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addverificationphotourl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                schema: "Doss",
                table: "VerificationMessage",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                schema: "Doss",
                table: "ServiceProvider",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                schema: "Doss",
                table: "Residential",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                schema: "Doss",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                schema: "Doss",
                table: "Residential");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                schema: "Doss",
                table: "VerificationMessage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
