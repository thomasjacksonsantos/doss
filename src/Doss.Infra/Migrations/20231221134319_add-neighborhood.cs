using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addneighborhood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_Neighborhood",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Neighborhood",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                schema: "Doss",
                table: "OnBoardAddress",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Neighborhood",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_Neighborhood",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                schema: "Doss",
                table: "OnBoardAddress");
        }
    }
}
