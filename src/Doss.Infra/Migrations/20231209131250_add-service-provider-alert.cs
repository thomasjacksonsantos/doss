using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addserviceprovideralert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardResidential_Plans_PlanId",
                schema: "Doss",
                table: "OnBoardResidential");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialWithServiceProvider_Plans_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plans",
                schema: "Doss",
                table: "Plans");

            migrationBuilder.RenameTable(
                name: "Plans",
                schema: "Doss",
                newName: "Plan",
                newSchema: "Doss");

            migrationBuilder.RenameIndex(
                name: "IX_Plans_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plan",
                newName: "IX_Plan_ServiceProviderPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plan",
                schema: "Doss",
                table: "Plan",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ServiceProviderAlert",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderAlert", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardResidential_Plan_PlanId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "PlanId",
                principalSchema: "Doss",
                principalTable: "Plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plan",
                column: "ServiceProviderPlanId",
                principalSchema: "Doss",
                principalTable: "ServiceProviderPlan",
                principalColumn: "Id");

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
                name: "FK_OnBoardResidential_Plan_PlanId",
                schema: "Doss",
                table: "OnBoardResidential");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plan");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialWithServiceProvider_Plan_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropTable(
                name: "ServiceProviderAlert",
                schema: "Doss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plan",
                schema: "Doss",
                table: "Plan");

            migrationBuilder.RenameTable(
                name: "Plan",
                schema: "Doss",
                newName: "Plans",
                newSchema: "Doss");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans",
                newName: "IX_Plans_ServiceProviderPlanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plans",
                schema: "Doss",
                table: "Plans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardResidential_Plans_PlanId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "PlanId",
                principalSchema: "Doss",
                principalTable: "Plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans",
                column: "ServiceProviderPlanId",
                principalSchema: "Doss",
                principalTable: "ServiceProviderPlan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialWithServiceProvider_Plans_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                column: "PlanId",
                principalSchema: "Doss",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
