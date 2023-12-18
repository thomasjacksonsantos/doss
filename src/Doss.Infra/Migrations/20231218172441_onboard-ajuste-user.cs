using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class onboardajusteuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardResidential_OnBoardUser_UserId",
                schema: "Doss",
                table: "OnBoardResidential");

            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardServiceProvider_OnBoardUser_UserId",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "OnBoardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardServiceProvider_UserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "IX_OnBoardServiceProvider_OnBoardUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "OnBoardUserId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardResidential_UserId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "IX_OnBoardResidential_OnBoardUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardResidential_OnBoardUser_OnBoardUserId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "OnBoardUserId",
                principalSchema: "Doss",
                principalTable: "OnBoardUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardServiceProvider_OnBoardUser_OnBoardUserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "OnBoardUserId",
                principalSchema: "Doss",
                principalTable: "OnBoardUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardResidential_OnBoardUser_OnBoardUserId",
                schema: "Doss",
                table: "OnBoardResidential");

            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardServiceProvider_OnBoardUser_OnBoardUserId",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.RenameColumn(
                name: "OnBoardUserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardServiceProvider_OnBoardUserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "IX_OnBoardServiceProvider_UserId");

            migrationBuilder.RenameColumn(
                name: "OnBoardUserId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardResidential_OnBoardUserId",
                schema: "Doss",
                table: "OnBoardResidential",
                newName: "IX_OnBoardResidential_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardResidential_OnBoardUser_UserId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "UserId",
                principalSchema: "Doss",
                principalTable: "OnBoardUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardServiceProvider_OnBoardUser_UserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "UserId",
                principalSchema: "Doss",
                principalTable: "OnBoardUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
