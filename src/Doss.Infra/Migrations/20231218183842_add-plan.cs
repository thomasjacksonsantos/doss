using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialWithServiceProvider_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialWithServiceProvider_Plan_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                column: "PlanId",
                principalSchema: "Doss",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialWithServiceProvider_Plan_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialWithServiceProvider_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");
        }
    }
}
