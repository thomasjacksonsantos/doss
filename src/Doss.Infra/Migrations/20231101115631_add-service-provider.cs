using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addserviceprovider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VehicleType",
                schema: "Doss",
                table: "Vehicle",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "OnBoardVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Model = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Plate = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    DefaultVehicle = table.Column<bool>(type: "bit", nullable: false),
                    VehicleType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnBoardServiceProvider",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverageArea = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Step = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OnBoardVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardServiceProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnBoardServiceProvider_OnBoardAddress_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Doss",
                        principalTable: "OnBoardAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnBoardServiceProvider_OnBoardUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Doss",
                        principalTable: "OnBoardUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnBoardServiceProvider_OnBoardVehicle_OnBoardVehicleId",
                        column: x => x.OnBoardVehicleId,
                        principalSchema: "Doss",
                        principalTable: "OnBoardVehicle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnBoardServiceProvider_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Doss",
                        principalTable: "Plans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnBoardServiceProvider_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_AddressId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_OnBoardVehicleId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "OnBoardVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_PlanId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_UserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnBoardServiceProvider",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardVehicle",
                schema: "Doss");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleType",
                schema: "Doss",
                table: "Vehicle",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);
        }
    }
}
