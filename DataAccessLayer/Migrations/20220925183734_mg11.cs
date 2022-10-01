using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mg11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Logs");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Pings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Pings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Pings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pings");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
