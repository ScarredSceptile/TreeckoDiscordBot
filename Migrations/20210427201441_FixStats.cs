using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeckoV2.Migrations
{
    public partial class FixStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Stats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "PokedexEntry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stats",
                table: "Stats",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PokedexEntry",
                table: "PokedexEntry",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stats",
                table: "Stats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PokedexEntry",
                table: "PokedexEntry");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "PokedexEntry");
        }
    }
}
