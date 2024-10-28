using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonOfGhosts.Migrations
{
    /// <inheritdoc />
    public partial class AdjustCodeLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Campaigns",
                type: "character(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Campaigns",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(10)",
                oldFixedLength: true,
                oldMaxLength: 10);
        }
    }
}
