using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Doss");

            migrationBuilder.CreateTable(
                name: "Bank",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    BankStatus = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnBoardAddress",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    City = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Complement = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "varchar(600)", maxLength: 600, nullable: false),
                    TypeDocument = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Document = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardUser", x => x.Id);
                });

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
                name: "Residential",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(600)", maxLength: 600, nullable: false),
                    Document = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TypeDocument = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    CompletedRegistration = table.Column<bool>(type: "bit", nullable: false),
                    UserStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(600)", maxLength: 600, nullable: false),
                    Document = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TypeDocument = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Photo = table.Column<string>(type: "text", nullable: false),
                    CompletedRegistration = table.Column<bool>(type: "bit", nullable: false),
                    UserStatus = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderAlert",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderAlert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnBoardServiceProvider",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TokenUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverageArea = table.Column<int>(type: "int", nullable: false),
                    AgencyBank = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AccountBank = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Step = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OnBoardVehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TermsAccept = table.Column<bool>(type: "bit", nullable: true),
                    DateTimeAccept = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnBoardServiceProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnBoardServiceProvider_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "Doss",
                        principalTable: "Bank",
                        principalColumn: "Id");
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
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderPlan",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountBank = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    AgencyBank = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Address_Country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address_State = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address_City = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Address_Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Address_Complement = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address_Latitude = table.Column<double>(type: "float", nullable: false),
                    Address_Longitude = table.Column<double>(type: "float", nullable: false),
                    Address_Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    CoverageArea = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviderPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProviderPlan_Bank_BankId",
                        column: x => x.BankId,
                        principalSchema: "Doss",
                        principalTable: "Bank",
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

            migrationBuilder.CreateTable(
                name: "Vehicle",
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
                    VehicleType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
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
                name: "OnBoardPlan",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlanStatus = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceProviderPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_ServiceProviderPlan_ServiceProviderPlanId",
                        column: x => x.ServiceProviderPlanId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProviderPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResidentialWithServiceProvider",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResidentialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceProviderPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_Country = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address_State = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address_City = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Address_Street = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Address_Complement = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address_Latitude = table.Column<double>(type: "float", nullable: false),
                    Address_Longitude = table.Column<double>(type: "float", nullable: false),
                    Address_Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialWithServiceProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialWithServiceProvider_Residential_ResidentialId",
                        column: x => x.ResidentialId,
                        principalSchema: "Doss",
                        principalTable: "Residential",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidentialWithServiceProvider_ServiceProviderPlan_ServiceProviderPlanId",
                        column: x => x.ServiceProviderPlanId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProviderPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnBoardResidential",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TokenUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Step = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TermsAccept = table.Column<bool>(type: "bit", nullable: true),
                    DateTimeAccept = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        name: "FK_OnBoardResidential_Plan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "Doss",
                        principalTable: "Plan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OnBoardResidential_ServiceProvider_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ServiceProvider",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResidentialVerificationRequest",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResidentialWithServiceProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialVerificationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialVerificationRequest_ResidentialWithServiceProvider_ResidentialWithServiceProviderId",
                        column: x => x.ResidentialWithServiceProviderId,
                        principalSchema: "Doss",
                        principalTable: "ResidentialWithServiceProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificationMessage",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialVerificationRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationMessage_ResidentialVerificationRequest_ResidentialVerificationRequestId",
                        column: x => x.ResidentialVerificationRequestId,
                        principalSchema: "Doss",
                        principalTable: "ResidentialVerificationRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardPlan_OnBoardServiceProviderId",
                schema: "Doss",
                table: "OnBoardPlan",
                column: "OnBoardServiceProviderId");

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
                name: "IX_OnBoardServiceProvider_AddressId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_BankId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_OnBoardVehicleId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "OnBoardVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_OnBoardServiceProvider_UserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_ServiceProviderPlanId",
                schema: "Doss",
                table: "Plan",
                column: "ServiceProviderPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialVerificationRequest_ResidentialWithServiceProviderId",
                schema: "Doss",
                table: "ResidentialVerificationRequest",
                column: "ResidentialWithServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialWithServiceProvider_ResidentialId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                column: "ResidentialId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialWithServiceProvider_ServiceProviderPlanId",
                schema: "Doss",
                table: "ResidentialWithServiceProvider",
                column: "ServiceProviderPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderPlan_BankId",
                schema: "Doss",
                table: "ServiceProviderPlan",
                column: "BankId");

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

            migrationBuilder.CreateIndex(
                name: "IX_VerificationMessage_ResidentialVerificationRequestId",
                schema: "Doss",
                table: "VerificationMessage",
                column: "ResidentialVerificationRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnBoardPlan",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardResidential",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ServiceProviderAlert",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Vehicle",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "VerificationMessage",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardServiceProvider",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Plan",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ResidentialVerificationRequest",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardAddress",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardUser",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "OnBoardVehicle",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ResidentialWithServiceProvider",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Residential",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ServiceProviderPlan",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "Bank",
                schema: "Doss");

            migrationBuilder.DropTable(
                name: "ServiceProvider",
                schema: "Doss");
        }
    }
}
