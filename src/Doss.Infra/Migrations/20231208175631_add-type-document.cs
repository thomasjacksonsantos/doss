using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addtypedocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                schema: "Doss",
                table: "ServiceProvider",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                schema: "Doss",
                table: "Residential",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeDocument",
                schema: "Doss",
                table: "OnBoardUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeDocument",
                schema: "Doss",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                schema: "Doss",
                table: "Residential");

            migrationBuilder.DropColumn(
                name: "TypeDocument",
                schema: "Doss",
                table: "OnBoardUser");
        }
    }
}
