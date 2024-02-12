using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class removephotoproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Photo",
                schema: "Doss",
                table: "Residential");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                schema: "Doss",
                table: "Vehicle",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                schema: "Doss",
                table: "Residential",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
