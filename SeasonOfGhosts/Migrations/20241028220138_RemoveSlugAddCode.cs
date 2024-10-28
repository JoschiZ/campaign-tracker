using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonOfGhosts.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSlugAddCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UrlSlug",
                table: "Campaigns",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Campaigns",
                newName: "UrlSlug");
        }
    }
}
