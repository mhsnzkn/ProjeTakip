using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeYonetim.Migrations
{
    public partial class aciklamaForRapor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Raporlar",
                maxLength: 400,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Raporlar");
        }
    }
}
