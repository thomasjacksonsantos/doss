using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class addtermsacceptserviceprovider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAccept",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TermsAccept",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeAccept",
                schema: "Doss",
                table: "OnBoardServiceProvider");

            migrationBuilder.DropColumn(
                name: "TermsAccept",
                schema: "Doss",
                table: "OnBoardServiceProvider");
        }
    }
}
