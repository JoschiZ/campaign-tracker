using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonOfGhosts.Migrations
{
    /// <inheritdoc />
    public partial class ReworkCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ancestry",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "Influence",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NewAttitude",
                table: "CharacterLog",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Delta",
                table: "CharacterLog",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogType",
                table: "CharacterLog",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Influence",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Delta",
                table: "CharacterLog");

            migrationBuilder.DropColumn(
                name: "LogType",
                table: "CharacterLog");

            migrationBuilder.AddColumn<string>(
                name: "Ancestry",
                table: "Characters",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Characters",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "NewAttitude",
                table: "CharacterLog",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
