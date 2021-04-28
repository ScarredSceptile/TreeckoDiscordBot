using Microsoft.EntityFrameworkCore.Migrations;

namespace TreeckoV2.Migrations
{
    public partial class ResetMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    JapaneseName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Effect = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    ID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Prefix = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    PowerPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: true),
                    Accuracy = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryEffect = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryEffectRate = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OldPokes",
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
                    table.PrimaryKey("PK_OldPokes", x => x.DexNr);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    DexNr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    japName = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Classification = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    Pic = table.Column<string>(type: "TEXT", nullable: true),
                    PicShiny = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.DexNr);
                });

            migrationBuilder.CreateTable(
                name: "EggMoves",
                columns: table => new
                {
                    PokemonNr = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Games = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_EggMoves_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EggMoves_Pokemon_PokemonNr",
                        column: x => x.PokemonNr,
                        principalTable: "Pokemon",
                        principalColumn: "DexNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelUpMoves",
                columns: table => new
                {
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonNr = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Games = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LevelUpMoves_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelUpMoves_Pokemon_PokemonNr",
                        column: x => x.PokemonNr,
                        principalTable: "Pokemon",
                        principalColumn: "DexNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokedexEntry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonNr = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Game = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokedexEntry", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PokedexEntry_Pokemon_PokemonNr",
                        column: x => x.PokemonNr,
                        principalTable: "Pokemon",
                        principalColumn: "DexNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonNr = table.Column<int>(type: "INTEGER", nullable: false),
                    Generation = table.Column<string>(type: "TEXT", nullable: true),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Special_Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Special_Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stats_Pokemon_PokemonNr",
                        column: x => x.PokemonNr,
                        principalTable: "Pokemon",
                        principalColumn: "DexNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TMHMMoves",
                columns: table => new
                {
                    PokemonNr = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Games = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TMHMMoves_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TMHMMoves_Pokemon_PokemonNr",
                        column: x => x.PokemonNr,
                        principalTable: "Pokemon",
                        principalColumn: "DexNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TutorMoves",
                columns: table => new
                {
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonNr = table.Column<int>(type: "INTEGER", nullable: false),
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false),
                    Games = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TutorMoves_Moves_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Moves",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorMoves_Pokemon_PokemonNr",
                        column: x => x.PokemonNr,
                        principalTable: "Pokemon",
                        principalColumn: "DexNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EggMoves_MoveId",
                table: "EggMoves",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_EggMoves_PokemonNr",
                table: "EggMoves",
                column: "PokemonNr");

            migrationBuilder.CreateIndex(
                name: "IX_LevelUpMoves_MoveId",
                table: "LevelUpMoves",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelUpMoves_PokemonNr",
                table: "LevelUpMoves",
                column: "PokemonNr");

            migrationBuilder.CreateIndex(
                name: "IX_PokedexEntry_PokemonNr",
                table: "PokedexEntry",
                column: "PokemonNr");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_PokemonNr",
                table: "Stats",
                column: "PokemonNr");

            migrationBuilder.CreateIndex(
                name: "IX_TMHMMoves_MoveId",
                table: "TMHMMoves",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_TMHMMoves_PokemonNr",
                table: "TMHMMoves",
                column: "PokemonNr");

            migrationBuilder.CreateIndex(
                name: "IX_TutorMoves_MoveId",
                table: "TutorMoves",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_TutorMoves_PokemonNr",
                table: "TutorMoves",
                column: "PokemonNr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "EggMoves");

            migrationBuilder.DropTable(
                name: "Guilds");

            migrationBuilder.DropTable(
                name: "LevelUpMoves");

            migrationBuilder.DropTable(
                name: "OldPokes");

            migrationBuilder.DropTable(
                name: "PokedexEntry");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "TMHMMoves");

            migrationBuilder.DropTable(
                name: "TutorMoves");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
