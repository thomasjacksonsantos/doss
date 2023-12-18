using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addserviceprovideplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardResidential_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardResidential");

            migrationBuilder.RenameColumn(
                name: "ServiceProviderId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "ServiceProviderPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardResidential_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "IX_OnBoardResidential_ServiceProviderPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardResidential_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "ServiceProviderPlanId",
                principalSchema: "Doss",
                principalTable: "ServiceProviderPlan",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardResidential_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "OnBoardResidential");

            migrationBuilder.RenameColumn(
                name: "ServiceProviderPlanId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "ServiceProviderId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardResidential_ServiceProviderPlanId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "IX_OnBoardResidential_ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardResidential_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "ServiceProviderId",
                principalSchema: "Doss",
                principalTable: "ServiceProvider",
                principalColumn: "Id");
        }
    }
}
