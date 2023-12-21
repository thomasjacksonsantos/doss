using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addResidentialWithServiceProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialVehicle_ResidentialWithServiceProvider_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialVehicle_ResidentialWithServiceProvider_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "ResidentialWithServiceProviderId",
                principalSchema: "Doss",
                principalTable: "ResidentialWithServiceProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialVehicle_ResidentialWithServiceProvider_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialVehicle_ResidentialWithServiceProvider_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVehicle",
                column: "ResidentialWithServiceProviderId",
                principalSchema: "Doss",
                principalTable: "ResidentialWithServiceProvider",
                principalColumn: "Id");
        }
    }
}
