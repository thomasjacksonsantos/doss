using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class removeserviceprovider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardServiceProvider_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.DropIndex(
                name: "IX_OnBoardServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardServiceProvider");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardServiceProvider_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "ServiceProviderId",
                principalSchema: "Doss",
                principalTable: "ServiceProvider",
                principalColumn: "Id");
        }
    }
}
