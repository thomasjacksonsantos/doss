using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class alterarestruturavehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Residential_ResidentialId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "UserVehicle",
                schema: "Doss");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ResidentialId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ResidentialId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.CreateTable(
                name: "ResidentialVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResidentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialVehicle_Residential_ResidentialId",
                        column: x => x.ResidentialId,
                        principalSchema: "Doss",
                        principalTable: "Residential",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialVehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "Doss",
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderVehicle_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderVehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "Doss",
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialVehicle_ResidentialId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "ResidentialId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialVehicle_VehicleId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderVehicle_ServiceProviderId",
                schema: "Doss",
                table: "ServiceProviderVehicle",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderVehicle_VehicleId",
                schema: "Doss",
                table: "ServiceProviderVehicle",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentialVehicle",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ServiceProviderVehicle",
                schema: "Doss");

            migrationBuilder.AddColumn<Guid>(
                name: "ResidentialId",
                schema: "Doss",
                table: "Vehicle",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVehicle_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserVehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "Doss",
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ResidentialId",
                schema: "Doss",
                table: "Vehicle",
                column: "ResidentialId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicle_ServiceProviderId",
                schema: "Doss",
                table: "UserVehicle",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicle_VehicleId",
                schema: "Doss",
                table: "UserVehicle",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Residential_ResidentialId",
                schema: "Doss",
                table: "Vehicle",
                column: "ResidentialId",
                principalSchema: "Doss",
                principalTable: "Residential",
                principalColumn: "Id");
        }
    }
}
