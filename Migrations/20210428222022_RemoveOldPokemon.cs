using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeckoV2.Migrations
{
    public partial class RemoveOldPokemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OldPokes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OldPokes",
                columns: table => new
                {
                    DexNr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Atk = table.Column<int>(type: "INTEGER", nullable: false),
                    Classification = table.Column<string>(type: "TEXT", nullable: true),
                    Def = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Pic = table.Column<string>(type: "TEXT", nullable: true),
                    PicShiny = table.Column<string>(type: "TEXT", nullable: true),
                    SpAtk = table.Column<int>(type: "INTEGER", nullable: false),
                    SpDef = table.Column<int>(type: "INTEGER", nullable: false),
                    Spd = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    japName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldPokes", x => x.DexNr);
                });
        }
    }
}
