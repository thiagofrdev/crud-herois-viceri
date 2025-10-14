using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Superheroes.Api.Migrations
{
    /// <inheritdoc />
    public partial class SuperpoderesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Superpoderes",
                columns: new[] { "Id", "Descricao", "Superpoder" },
                values: new object[,]
                {
                    { 1, "Capacidade de voar", "Voo" },
                    { 2, "Força física sobre-humana", "Super Força" },
                    { 3, "Capacidade de se tornar invisível", "Invisibilidade" },
                    { 4, "Capacidade de ir de um lugar a outro instantaneamente", "Teletransporte" },
                    { 5, "Capacidade de reduzir seu tamanho a níveis microscópicos", "Diminuir de tamanho" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Superpoderes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
