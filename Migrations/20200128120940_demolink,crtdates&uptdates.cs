using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeYonetim.Migrations
{
    public partial class demolinkcrtdatesuptdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CrtDate",
                table: "RaporTurleri",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UptDate",
                table: "RaporTurleri",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UptDate",
                table: "Raporlar",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CrtDate",
                table: "Projeler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UptDate",
                table: "Projeler",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CrtDate",
                table: "Moduller",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DemoLink",
                table: "Moduller",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UptDate",
                table: "Moduller",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CrtDate",
                table: "Kullanici",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UptDate",
                table: "Kullanici",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrtDate",
                table: "RaporTurleri");

            migrationBuilder.DropColumn(
                name: "UptDate",
                table: "RaporTurleri");

            migrationBuilder.DropColumn(
                name: "UptDate",
                table: "Raporlar");

            migrationBuilder.DropColumn(
                name: "CrtDate",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "UptDate",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "CrtDate",
                table: "Moduller");

            migrationBuilder.DropColumn(
                name: "DemoLink",
                table: "Moduller");

            migrationBuilder.DropColumn(
                name: "UptDate",
                table: "Moduller");

            migrationBuilder.DropColumn(
                name: "CrtDate",
                table: "Kullanici");

            migrationBuilder.DropColumn(
                name: "UptDate",
                table: "Kullanici");
        }
    }
}
