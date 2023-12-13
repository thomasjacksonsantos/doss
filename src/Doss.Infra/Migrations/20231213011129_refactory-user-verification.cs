using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class refactoryuserverification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message",
                schema: "Doss");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Doss",
                table: "Verification");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Doss",
                table: "ServiceProvider");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Doss",
                table: "Residential");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                schema: "Doss",
                table: "Verification",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VerificationMessage",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificationMessage_Verification_VerificationId",
                        column: x => x.VerificationId,
                        principalSchema: "Doss",
                        principalTable: "Verification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VerificationMessage_VerificationId",
                schema: "Doss",
                table: "VerificationMessage",
                column: "VerificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationMessage",
                schema: "Doss");

            migrationBuilder.DropColumn(
                name: "Message",
                schema: "Doss",
                table: "Verification");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Doss",
                table: "Verification",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Doss",
                table: "ServiceProvider",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Doss",
                table: "Residential",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Doss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Verification_VerificationId",
                        column: x => x.VerificationId,
                        principalSchema: "Doss",
                        principalTable: "Verification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_VerificationId",
                schema: "Doss",
                table: "Message",
                column: "VerificationId");
        }
    }
}
