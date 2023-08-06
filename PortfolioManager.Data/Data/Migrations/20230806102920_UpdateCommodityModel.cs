using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommodityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoingeckoId",
                table: "Commodity",
                newName: "ApiId");

            migrationBuilder.UpdateData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bitcoin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApiId",
                table: "Commodity",
                newName: "CoingeckoId");

            migrationBuilder.UpdateData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bitcon");
        }
    }
}
