using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class alterresidentialvehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialVehicle_Residential_ResidentialId",
                schema: "Doss",
                table: "ResidentialVehicle");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialVehicle_ResidentialId",
                schema: "Doss",
                table: "ResidentialVehicle");

            migrationBuilder.AddColumn<Guid>(
                name: "ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialVehicle_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "ResidentialWithServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialVehicle_ResidentialWithServiceProvider_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "ResidentialWithServiceProviderId",
                principalSchema: "Doss",
                principalTable: "ResidentialWithServiceProvider",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialVehicle_ResidentialWithServiceProvider_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle");

            migrationBuilder.DropIndex(
                name: "IX_ResidentialVehicle_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle");

            migrationBuilder.DropColumn(
                name: "ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialVehicle_ResidentialId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "ResidentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialVehicle_Residential_ResidentialId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "ResidentialId",
                principalSchema: "Doss",
                principalTable: "Residential",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
