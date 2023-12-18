using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class verifyuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "Doss",
                table: "ResidentialVerificationRequest",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4000)",
                oldMaxLength: 4000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "Doss",
                table: "ResidentialVerificationRequest",
                type: "varchar(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300);
        }
    }
}
