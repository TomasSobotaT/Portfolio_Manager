using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstModelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommoditiesDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    InvestedMoney = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommoditiesDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommoditiesTestDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    InvestedMoney = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommoditiesTestDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricDataDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceCZK = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                    PriceUSD = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricDataDbSet", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CommoditiesTestDbSet",
                columns: new[] { "Id", "Amount", "InvestedMoney", "Name" },
                values: new object[] { 1, 0.0, 100000m, "bitcon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommoditiesDbSet");

            migrationBuilder.DropTable(
                name: "CommoditiesTestDbSet");

            migrationBuilder.DropTable(
                name: "HistoricDataDbSet");
        }
    }
}
