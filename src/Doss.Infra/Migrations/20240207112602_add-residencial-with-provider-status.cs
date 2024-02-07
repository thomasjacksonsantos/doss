using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addresidencialwithproviderstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResidentialWithServiceProviderStatus",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResidentialWithServiceProviderStatus",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");
        }
    }
}
