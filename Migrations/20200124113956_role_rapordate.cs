using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeYonetim.Migrations
{
    public partial class role_rapordate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CrtDate",
                table: "Raporlar",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "Raporlar",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Kullanici",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrtDate",
                table: "Raporlar");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "Raporlar");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Kullanici");
        }
    }
}
