using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeYonetim.Migrations
{
    public partial class activesiraformodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "RaporTurleri",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Raporlar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Projeler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Sira",
                table: "Projeler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Moduller",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Kullanici",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "RaporTurleri");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Raporlar");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "Sira",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Moduller");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Kullanici");
        }
    }
}
