using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class fkonboardplandeletecascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardPlan_OnBoardServiceProvider_OnBoardServiceProviderId",
                schema: "Doss",
                table: "OnBoardPlan");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardPlan_OnBoardServiceProvider_OnBoardServiceProviderId",
                schema: "Doss",
                table: "OnBoardPlan",
                column: "OnBoardServiceProviderId",
                principalSchema: "Doss",
                principalTable: "OnBoardServiceProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardPlan_OnBoardServiceProvider_OnBoardServiceProviderId",
                schema: "Doss",
                table: "OnBoardPlan");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardPlan_OnBoardServiceProvider_OnBoardServiceProviderId",
                schema: "Doss",
                table: "OnBoardPlan",
                column: "OnBoardServiceProviderId",
                principalSchema: "Doss",
                principalTable: "OnBoardServiceProvider",
                principalColumn: "Id");
        }
    }
}
