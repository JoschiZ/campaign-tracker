using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonOfGhosts.Migrations
{
    /// <inheritdoc />
    public partial class AddMainSettlement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainSettlementId",
                table: "Campaigns",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_MainSettlementId",
                table: "Campaigns",
                column: "MainSettlementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Settlements_MainSettlementId",
                table: "Campaigns",
                column: "MainSettlementId",
                principalTable: "Settlements",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Settlements_MainSettlementId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_MainSettlementId",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "MainSettlementId",
                table: "Campaigns");
        }
    }
}
