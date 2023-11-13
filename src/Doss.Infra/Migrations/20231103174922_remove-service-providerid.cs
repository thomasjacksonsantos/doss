using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doss.Infra.Migrations
{
    public partial class removeserviceproviderid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceProviderId",
                schema: "Doss",
                table: "OnBoardServiceProvider");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ServiceProviderId",
                schema: "Doss",
                table: "OnBoardServiceProvider",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
