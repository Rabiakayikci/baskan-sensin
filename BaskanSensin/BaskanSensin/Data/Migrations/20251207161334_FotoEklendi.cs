using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaskanSensin.Data.Migrations
{
    /// <inheritdoc />
    public partial class FotoEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Yapilar",
                keyColumn: "Yapid",
                keyValue: 2,
                column: "Resim",
                value: "muhendis.jpeg");

            migrationBuilder.UpdateData(
                table: "Yapilar",
                keyColumn: "Yapid",
                keyValue: 3,
                column: "Resim",
                value: "adalet.jpeg");

            migrationBuilder.UpdateData(
                table: "Yapilar",
                keyColumn: "Yapid",
                keyValue: 4,
                column: "Resim",
                value: "sanat.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Yapilar",
                keyColumn: "Yapid",
                keyValue: 2,
                column: "Resim",
                value: "garden.png");

            migrationBuilder.UpdateData(
                table: "Yapilar",
                keyColumn: "Yapid",
                keyValue: 3,
                column: "Resim",
                value: "library.png");

            migrationBuilder.UpdateData(
                table: "Yapilar",
                keyColumn: "Yapid",
                keyValue: 4,
                column: "Resim",
                value: "garden.png");
        }
    }
}
