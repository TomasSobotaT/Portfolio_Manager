using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class EveryUserHisOwnCommodity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Commodity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Commodity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Commodity_ApplicationUserId",
                table: "Commodity",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commodity_AspNetUsers_ApplicationUserId",
                table: "Commodity",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commodity_AspNetUsers_ApplicationUserId",
                table: "Commodity");

            migrationBuilder.DropIndex(
                name: "IX_Commodity_ApplicationUserId",
                table: "Commodity");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Commodity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Commodity",
                columns: new[] { "Id", "Amount", "ApiId", "InvestedMoney", "Name", "Type" },
                values: new object[] { 1, 0.0, "bitcoin", 100000m, "Bitcoin", "crypto" });
        }
    }
}
