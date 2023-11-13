using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class IniialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Doss");

            migrationBuilder.CreateTable(
                name: "OnBoardAddress",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnBoardUser",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanStatus = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Residential",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedRegistration = table.Column<bool>(type: "bit", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedRegistration = table.Column<bool>(type: "bit", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ResidentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Address_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OnBoardResidential",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Step = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardResidential", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnBoardResidential_OnBoardAddress_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Doss",
                        principalTable: "OnBoardAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnBoardResidential_OnBoardUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "Doss",
                        principalTable: "OnBoardUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnBoardResidential_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Doss",
                        principalTable: "Plans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnBoardResidential_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResidentialWithServiceProvider",
                schema: "Doss",
                columns: table => new
                {
                    ResidentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialWithServiceProvider", x => new { x.ResidentialId, x.ServiceProviderId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_ResidentialWithServiceProvider_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Doss",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialWithServiceProvider_Residential_ResidentialId",
                        column: x => x.ResidentialId,
                        principalSchema: "Doss",
                        principalTable: "Residential",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialWithServiceProvider_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultVehicle = table.Column<bool>(type: "bit", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResidentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Residential_ResidentialId",
                        column: x => x.ResidentialId,
                        principalSchema: "Doss",
                        principalTable: "Residential",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderPlan",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Limit = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderPlan_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Doss",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderPlan_Plans_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Doss",
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProviderPlan_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ResidentialId",
                schema: "Doss",
                table: "Address",
                column: "ResidentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ServiceProviderId",
                schema: "Doss",
                table: "Address",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardResidential_AddressId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardResidential_PlanId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardResidential_ServiceProviderId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardResidential_UserId",
                schema: "Doss",
                table: "OnBoardResidential",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialWithServiceProvider_PlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialWithServiceProvider_ServiceProviderId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPlan_AddressId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPlan_PlanId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPlan_ServiceProviderId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ResidentialId",
                schema: "Doss",
                table: "Vehicle",
                column: "ResidentialId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ServiceProviderId",
                schema: "Doss",
                table: "Vehicle",
                column: "ServiceProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnBoardResidential",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ResidentialWithServiceProvider",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ServiceProviderPlan",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Vehicle",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardAddress",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardUser",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Plans",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Residential",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ServiceProvider",
                schema: "Doss");
        }
    }
}
