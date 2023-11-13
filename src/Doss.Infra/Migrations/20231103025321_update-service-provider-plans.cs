using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class updateserviceproviderplans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderPlan_Plans_PlanId",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropIndex(
                name: "IX_Address_ServiceProviderId",
                schema: "Doss",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                schema: "Doss",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                newName: "BankId");

            migrationBuilder.RenameColumn(
                name: "Limit",
                schema: "Doss",
                table: "ServiceProviderPlan",
                newName: "CoverageArea");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProviderPlan_PlanId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                newName: "IX_ServiceProviderPlan_BankId");

            migrationBuilder.AddColumn<string>(
                name: "AccountBank",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "varchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AgencyBank",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "varchar(160)",
                maxLength: 160,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans",
                column: "ServiceProviderPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans",
                column: "ServiceProviderPlanId",
                principalSchema: "Doss",
                principalTable: "ServiceProviderPlan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderPlan_Bank_BankId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "BankId",
                principalSchema: "Doss",
                principalTable: "Bank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_ServiceProviderPlan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderPlan_Bank_BankId",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropIndex(
                name: "IX_Plans_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "AccountBank",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "AgencyBank",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "ServiceProviderPlanId",
                schema: "Doss",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "CoverageArea",
                schema: "Doss",
                table: "ServiceProviderPlan",
                newName: "Limit");

            migrationBuilder.RenameColumn(
                name: "BankId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProviderPlan_BankId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                newName: "IX_ServiceProviderPlan_PlanId");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceProviderId",
                schema: "Doss",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ServiceProviderId",
                schema: "Doss",
                table: "Address",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "Address",
                column: "ServiceProviderId",
                principalSchema: "Doss",
                principalTable: "ServiceProvider",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderPlan_Plans_PlanId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "PlanId",
                principalSchema: "Doss",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
