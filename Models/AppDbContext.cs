using Microsoft.EntityFrameworkCore;

namespace TreeckoV2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokedexEntry> PokedexEntry { get; set; }
        public DbSet<PokemonAbilities> Abilities { get; set; }
        public DbSet<PokemonMoves> Moves { get; set; }
        public DbSet<PokemonStats> Stats { get; set; }
        public DbSet<PokemonMoveRelationLevelUp> LevelUpMoves { get; set; }
        public DbSet<PokemonMoveRelationTMHM> TMHMMoves { get; set; }
        public DbSet<PokemonMoveRelationTutor> TutorMoves { get; set; }
        public DbSet<PokemonMoveRelationEggMove> EggMoves { get; set; }
        public DbSet<DiscordGuild> Guilds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\Treecko\TreeckoV2\TreeckoV2\Data\Pokemon.sqlite");
        }
    }
}
