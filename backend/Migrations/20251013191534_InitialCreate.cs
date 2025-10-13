using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Superheroes.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Herois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    NomeHeroi = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Altura = table.Column<float>(type: "REAL", nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superpoderes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Superpoder = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superpoderes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroisSuperpoderes",
                columns: table => new
                {
                    HeroisId = table.Column<int>(type: "INTEGER", nullable: false),
                    SuperpoderesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisSuperpoderes", x => new { x.HeroisId, x.SuperpoderesId });
                    table.ForeignKey(
                        name: "FK_HeroisSuperpoderes_Herois_HeroisId",
                        column: x => x.HeroisId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisSuperpoderes_Superpoderes_SuperpoderesId",
                        column: x => x.SuperpoderesId,
                        principalTable: "Superpoderes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroisSuperpoderes_SuperpoderesId",
                table: "HeroisSuperpoderes",
                column: "SuperpoderesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroisSuperpoderes");

            migrationBuilder.DropTable(
                name: "Herois");

            migrationBuilder.DropTable(
                name: "Superpoderes");
        }
    }
}
