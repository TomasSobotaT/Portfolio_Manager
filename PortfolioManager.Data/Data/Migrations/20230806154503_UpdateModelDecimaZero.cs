﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelDecimaZero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "InvestedMoney",
                table: "Commodity",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "InvestedMoney",
                table: "Commodity",
                type: "decimal(18,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");
        }
    }
}
