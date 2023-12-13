using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addressnumberuserverification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderPlan_Address_AddressId",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Doss");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviderPlan_AddressId",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Complement",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Address_Latitude",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Address_Longitude",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Complement",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Address_Latitude",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Address_Longitude",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                schema: "Doss",
                table: "OnBoardAddress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_Complement",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                schema: "Doss",
                table: "ServiceProviderPlan");

            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_Complement",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_Latitude",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_Longitude",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                schema: "Doss",
                table: "ResidentialWithServiceProvider");

            migrationBuilder.DropColumn(
                name: "Number",
                schema: "Doss",
                table: "OnBoardAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Complement = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ResidentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    State = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Residential_ResidentialId",
                        column: x => x.ResidentialId,
                        principalSchema: "Doss",
                        principalTable: "Residential",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPlan_AddressId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ResidentialId",
                schema: "Doss",
                table: "Address",
                column: "ResidentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderPlan_Address_AddressId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "AddressId",
                principalSchema: "Doss",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
