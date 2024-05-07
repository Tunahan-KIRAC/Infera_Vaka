using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorePackeges.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepotId",
                table: "InventoryItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "InventoryItemId",
                table: "Depots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepotId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "Depots");
        }
    }
}
