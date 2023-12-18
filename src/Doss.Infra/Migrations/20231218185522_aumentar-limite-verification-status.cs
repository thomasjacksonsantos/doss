using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class aumentarlimiteverificationstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Doss",
                table: "ResidentialVerificationRequest",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "Doss",
                table: "ResidentialVerificationRequest",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);
        }
    }
}
