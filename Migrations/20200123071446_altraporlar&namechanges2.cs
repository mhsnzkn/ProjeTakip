using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeYonetim.Migrations
{
    public partial class altraporlarnamechanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modul_Proje_ProjeId",
                table: "Modul");

            migrationBuilder.DropForeignKey(
                name: "FK_Raporlar_Modul_ModulId",
                table: "Raporlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Raporlar_Proje_ProjeId",
                table: "Raporlar");

            migrationBuilder.DropTable(
                name: "AltRaporlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proje",
                table: "Proje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modul",
                table: "Modul");

            migrationBuilder.RenameTable(
                name: "Proje",
                newName: "Projeler");

            migrationBuilder.RenameTable(
                name: "Modul",
                newName: "Moduller");

            migrationBuilder.RenameIndex(
                name: "IX_Modul_ProjeId",
                table: "Moduller",
                newName: "IX_Moduller_ProjeId");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Raporlar",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaporTurId",
                table: "Raporlar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projeler",
                table: "Projeler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Moduller",
                table: "Moduller",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RaporTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjeId = table.Column<int>(nullable: false),
                    ModulId = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(maxLength: 100, nullable: true),
                    Sira = table.Column<int>(nullable: false),
                    Aciklama = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporTurleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaporTurleri_Moduller_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RaporTurleri_Projeler_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Projeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raporlar_RaporTurId",
                table: "Raporlar",
                column: "RaporTurId");

            migrationBuilder.CreateIndex(
                name: "IX_RaporTurleri_ModulId",
                table: "RaporTurleri",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_RaporTurleri_ProjeId",
                table: "RaporTurleri",
                column: "ProjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moduller_Projeler_ProjeId",
                table: "Moduller",
                column: "ProjeId",
                principalTable: "Projeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Raporlar_Moduller_ModulId",
                table: "Raporlar",
                column: "ModulId",
                principalTable: "Moduller",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Raporlar_Projeler_ProjeId",
                table: "Raporlar",
                column: "ProjeId",
                principalTable: "Projeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Raporlar_RaporTurleri_RaporTurId",
                table: "Raporlar",
                column: "RaporTurId",
                principalTable: "RaporTurleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moduller_Projeler_ProjeId",
                table: "Moduller");

            migrationBuilder.DropForeignKey(
                name: "FK_Raporlar_Moduller_ModulId",
                table: "Raporlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Raporlar_Projeler_ProjeId",
                table: "Raporlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Raporlar_RaporTurleri_RaporTurId",
                table: "Raporlar");

            migrationBuilder.DropTable(
                name: "RaporTurleri");

            migrationBuilder.DropIndex(
                name: "IX_Raporlar_RaporTurId",
                table: "Raporlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projeler",
                table: "Projeler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Moduller",
                table: "Moduller");

            migrationBuilder.DropColumn(
                name: "RaporTurId",
                table: "Raporlar");

            migrationBuilder.RenameTable(
                name: "Projeler",
                newName: "Proje");

            migrationBuilder.RenameTable(
                name: "Moduller",
                newName: "Modul");

            migrationBuilder.RenameIndex(
                name: "IX_Moduller_ProjeId",
                table: "Modul",
                newName: "IX_Modul_ProjeId");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "Raporlar",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proje",
                table: "Proje",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modul",
                table: "Modul",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AltRaporlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(maxLength: 100, nullable: true),
                    Link = table.Column<string>(maxLength: 300, nullable: true),
                    ModulId = table.Column<int>(nullable: false),
                    ProjeId = table.Column<int>(nullable: false),
                    RaporId = table.Column<int>(nullable: false),
                    Sira = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AltRaporlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AltRaporlar_Modul_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Modul",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AltRaporlar_Proje_ProjeId",
                        column: x => x.ProjeId,
                        principalTable: "Proje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AltRaporlar_Raporlar_RaporId",
                        column: x => x.RaporId,
                        principalTable: "Raporlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Modul_Proje_ProjeId",
                table: "Modul",
                column: "ProjeId",
                principalTable: "Proje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raporlar_Modul_ModulId",
                table: "Raporlar",
                column: "ModulId",
                principalTable: "Modul",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Raporlar_Proje_ProjeId",
                table: "Raporlar",
                column: "ProjeId",
                principalTable: "Proje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
