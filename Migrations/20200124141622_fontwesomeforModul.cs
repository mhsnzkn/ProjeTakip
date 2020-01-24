using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeYonetim.Migrations
{
    public partial class fontwesomeforModul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fontawesome",
                table: "Moduller",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fontawesome",
                table: "Moduller");
        }
    }
}
