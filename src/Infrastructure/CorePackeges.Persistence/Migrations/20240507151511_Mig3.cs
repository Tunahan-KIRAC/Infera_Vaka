using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorePackeges.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Depots_DepotId",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_DepotId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DepotId",
                table: "InventoryItems");

            migrationBuilder.CreateTable(
                name: "DepotInventoryItem",
                columns: table => new
                {
                    DepotsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepotInventoryItem", x => new { x.DepotsId, x.InventoryItemsId });
                    table.ForeignKey(
                        name: "FK_DepotInventoryItem_Depots_DepotsId",
                        column: x => x.DepotsId,
                        principalTable: "Depots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepotInventoryItem_InventoryItems_InventoryItemsId",
                        column: x => x.InventoryItemsId,
                        principalTable: "InventoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepotInventoryItem_InventoryItemsId",
                table: "DepotInventoryItem",
                column: "InventoryItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepotInventoryItem");

            migrationBuilder.AddColumn<Guid>(
                name: "DepotId",
                table: "InventoryItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_DepotId",
                table: "InventoryItems",
                column: "DepotId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Depots_DepotId",
                table: "InventoryItems",
                column: "DepotId",
                principalTable: "Depots",
                principalColumn: "Id");
        }
    }
}
