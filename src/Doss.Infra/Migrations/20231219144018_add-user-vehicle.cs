using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class adduservehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_VerificationMessage_ResidentialVerificationRequest_ResidentialVerificationRequestId",
                schema: "Doss",
                table: "VerificationMessage");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ServiceProviderId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                schema: "Doss",
                table: "Vehicle");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidentialVerificationRequestId",
                schema: "Doss",
                table: "VerificationMessage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "Doss",
                table: "VerificationMessage",
                type: "varchar(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "UserVehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "FK_VerificationMessage_ResidentialVerificationRequest_ResidentialVerificationRequestId",
                schema: "Doss",
                table: "VerificationMessage",
                column: "ResidentialVerificationRequestId",
                principalSchema: "Doss",
                principalTable: "ResidentialVerificationRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VerificationMessage_ResidentialVerificationRequest_ResidentialVerificationRequestId",
                schema: "Doss",
                table: "VerificationMessage");

            migrationBuilder.DropTable(
                name: "UserVehicle",
                schema: "Doss");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidentialVerificationRequestId",
                schema: "Doss",
                table: "VerificationMessage",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                schema: "Doss",
                table: "VerificationMessage",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceProviderId",
                schema: "Doss",
                table: "Vehicle",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ServiceProviderId",
                schema: "Doss",
                table: "Vehicle",
                column: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_ServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "Vehicle",
                column: "ServiceProviderId",
                principalSchema: "Doss",
                principalTable: "ServiceProvider",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VerificationMessage_ResidentialVerificationRequest_ResidentialVerificationRequestId",
                schema: "Doss",
                table: "VerificationMessage",
                column: "ResidentialVerificationRequestId",
                principalSchema: "Doss",
                principalTable: "ResidentialVerificationRequest",
                principalColumn: "Id");
        }
    }
}
