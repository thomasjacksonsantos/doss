using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class voltarversaoveiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_ModelVehicle_ModelVehicleId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "ModelVehicle",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "BrandVehicle",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "TypeVehicle",
                schema: "Doss");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ModelVehicleId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ModelVehicleId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ModelVehicleId",
                schema: "Doss",
                table: "OnBoardVehicle");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                schema: "Doss",
                table: "Vehicle",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "Doss",
                table: "Vehicle",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                schema: "Doss",
                table: "Vehicle",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                schema: "Doss",
                table: "OnBoardVehicle",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                schema: "Doss",
                table: "OnBoardVehicle",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleType",
                schema: "Doss",
                table: "OnBoardVehicle",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "Doss",
                table: "OnBoardVehicle");

            migrationBuilder.DropColumn(
                name: "Model",
                schema: "Doss",
                table: "OnBoardVehicle");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                schema: "Doss",
                table: "OnBoardVehicle");

            migrationBuilder.AddColumn<Guid>(
                name: "ModelVehicleId",
                schema: "Doss",
                table: "Vehicle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ModelVehicleId",
                schema: "Doss",
                table: "OnBoardVehicle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TypeVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandVehicle_TypeVehicle_TypeVehicleId",
                        column: x => x.TypeVehicleId,
                        principalSchema: "Doss",
                        principalTable: "TypeVehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelVehicle_BrandVehicle_BrandVehicleId",
                        column: x => x.BrandVehicleId,
                        principalSchema: "Doss",
                        principalTable: "BrandVehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelVehicleId",
                schema: "Doss",
                table: "Vehicle",
                column: "ModelVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandVehicle_TypeVehicleId",
                schema: "Doss",
                table: "BrandVehicle",
                column: "TypeVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelVehicle_BrandVehicleId",
                schema: "Doss",
                table: "ModelVehicle",
                column: "BrandVehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_ModelVehicle_ModelVehicleId",
                schema: "Doss",
                table: "Vehicle",
                column: "ModelVehicleId",
                principalSchema: "Doss",
                principalTable: "ModelVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
