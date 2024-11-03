using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonOfGhosts.Migrations
{
    /// <inheritdoc />
    public partial class LogRenamig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewAttitude",
                table: "CharacterLog",
                newName: "NewValue");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewValue",
                table: "CharacterLog",
                newName: "NewAttitude");
        }
    }
}
