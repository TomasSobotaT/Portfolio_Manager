using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class CommodityModelUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommoditiesTestDbSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommoditiesDbSet",
                table: "CommoditiesDbSet");

            migrationBuilder.RenameTable(
                name: "CommoditiesDbSet",
                newName: "Commodity");

            migrationBuilder.AddColumn<string>(
                name: "CoingeckoId",
                table: "Commodity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Commodity",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commodity",
                table: "Commodity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "Amount", "CoingeckoId", "InvestedMoney", "Name", "Type" },
                values: new object[] { 1, 0.0, "bitcoin", 100000m, "Bitcon", "crypto" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commodity",
                table: "Commodity");

            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CoingeckoId",
                table: "Commodity");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Commodity");

            migrationBuilder.RenameTable(
                name: "Commodity",
                newName: "CommoditiesDbSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommoditiesDbSet",
                table: "CommoditiesDbSet",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommoditiesTestDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    InvestedMoney = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommoditiesTestDbSet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CommoditiesTestDbSet",
                columns: new[] { "Id", "Amount", "InvestedMoney", "Name" },
                values: new object[] { 1, 0.0, 100000m, "bitcon" });
        }
    }
}
