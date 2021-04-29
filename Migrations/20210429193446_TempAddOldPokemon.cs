using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeckoV2.Migrations
{
    public partial class TempAddOldPokemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OldPokemon",
                columns: table => new
                {
                    DexNr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    japName = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Classification = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    Atk = table.Column<int>(type: "INTEGER", nullable: false),
                    Def = table.Column<int>(type: "INTEGER", nullable: false),
                    SpAtk = table.Column<int>(type: "INTEGER", nullable: false),
                    SpDef = table.Column<int>(type: "INTEGER", nullable: false),
                    Spd = table.Column<int>(type: "INTEGER", nullable: false),
                    Pic = table.Column<string>(type: "TEXT", nullable: true),
                    PicShiny = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldPokemon", x => x.DexNr);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OldPokemon");
        }
    }
}
