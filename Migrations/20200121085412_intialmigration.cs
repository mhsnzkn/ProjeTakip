using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeYonetim.Migrations
{
    public partial class intialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modul",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjeId = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(maxLength: 100, nullable: true),
                    Sira = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modul", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modul_Proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Raporlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjeId = table.Column<int>(nullable: false),
                    ModulId = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(maxLength: 100, nullable: true),
                    Sira = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raporlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raporlar_Modul_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Modul",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Raporlar_Proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AltRaporlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjeId = table.Column<int>(nullable: false),
                    ModulId = table.Column<int>(nullable: false),
                    RaporId = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(maxLength: 100, nullable: true),
                    Sira = table.Column<int>(nullable: false),
                    Link = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltRaporlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltRaporlar_Modul_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Modul",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AltRaporlar_Proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AltRaporlar_Raporlar_RaporId",
                        column: x => x.RaporId,
                        principalTable: "Raporlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AltRaporlar_ModulId",
                table: "AltRaporlar",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_AltRaporlar_ProjeId",
                table: "AltRaporlar",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_AltRaporlar_RaporId",
                table: "AltRaporlar",
                column: "RaporId");

            migrationBuilder.CreateIndex(
                name: "IX_Modul_ProjeId",
                table: "Modul",
                column: "ProjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Raporlar_ModulId",
                table: "Raporlar",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_Raporlar_ProjeId",
                table: "Raporlar",
                column: "ProjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AltRaporlar");

            migrationBuilder.DropTable(
                name: "Kullanici");

            migrationBuilder.DropTable(
                name: "Raporlar");

            migrationBuilder.DropTable(
                name: "Modul");

            migrationBuilder.DropTable(
                name: "Proje");
        }
    }
}
