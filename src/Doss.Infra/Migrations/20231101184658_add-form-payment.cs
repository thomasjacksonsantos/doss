using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addformpayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardServiceProvider_Plans_PlanId",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "BankId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardServiceProvider_PlanId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "IX_OnBoardServiceProvider_BankId");

            migrationBuilder.AddColumn<string>(
                name: "AccountBank",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AgencyBank",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankStatus = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnBoardPlan",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OnBoardServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnBoardPlan_OnBoardServiceProvider_OnBoardServiceProviderId",
                        column: x => x.OnBoardServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "OnBoardServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardPlan_OnBoardServiceProviderId",
                schema: "Doss",
                table: "OnBoardPlan",
                column: "OnBoardServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardServiceProvider_Bank_BankId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "BankId",
                principalSchema: "Doss",
                principalTable: "Bank",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnBoardServiceProvider_Bank_BankId",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.DropTable(
                name: "Bank",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardPlan",
                schema: "Doss");

            migrationBuilder.DropColumn(
                name: "AccountBank",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.DropColumn(
                name: "AgencyBank",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.RenameColumn(
                name: "BankId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_OnBoardServiceProvider_BankId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                newName: "IX_OnBoardServiceProvider_PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnBoardServiceProvider_Plans_PlanId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "PlanId",
                principalSchema: "Doss",
                principalTable: "Plans",
                principalColumn: "Id");
        }
    }
}
