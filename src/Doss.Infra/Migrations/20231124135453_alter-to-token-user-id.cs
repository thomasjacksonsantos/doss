using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class altertotokenuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TokenUserId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TokenUserId",
                schema: "Doss",
                table: "OnBoardResidential",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenUserId",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.DropColumn(
                name: "TokenUserId",
                schema: "Doss",
                table: "OnBoardResidential");
        }
    }
}
