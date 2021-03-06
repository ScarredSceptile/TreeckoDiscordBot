using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeckoV2.Models;

namespace TreeckoV2.Utility
{
    public static class PokemonUtility
    {
        public static List<Pokemon> GetPokemonEqualStats(int total, int length)
        {
            var context = new AppDbContext();

            var allPokes = context.Pokemon.ToList();

            List<Pokemon> pokes = new List<Pokemon>();

            foreach (var poke in allPokes)
            {
                if (poke.Name.Length != length && length != 0)
                    continue;

                var stats = context.Stats.AsQueryable().Where(s => s.PokemonNr == poke.DexNr).ToList();

                foreach (var stat in stats)
                {
                    if (EqualStatsAmount(stat) == total && !pokes.Contains(poke))
                        pokes.Add(poke);
                }
            }

            return pokes;
        }

        public static int EqualStatsAmount(PokemonStats stats)
        {
            var list = new List<int>
            {
                stats.HP,
                stats.Attack,
                stats.Defense,
                stats.Special_Attack,
                stats.Special_Defense,
                stats.Speed
            };

            int mostCommon = list.GroupBy(item => item).Max(item => item.Count());

            return mostCommon;
        }

        public static List<Pokemon> GetPokemonByIncompleteName(Dictionary<char, int> dict, int length)
        {
            var context = new AppDbContext();

            var pokes = context.Pokemon.AsEnumerable().Where(p => p.Name.Length == length).ToList().Where(p => dict.AsQueryable().ToArray().All(d => char.ToLower(p.Name[d.Value]) == char.ToLower(d.Key)) == true).ToList();

            return pokes;
        }

        public static EmbedBuilder PokeEmbed(Pokemon poke, PokemonStats stats, string image)
        {
            var embed = new EmbedBuilder();

            embed.WithAuthor($"{poke.DexNr}. {poke.Name} {poke.japName}");
            embed.WithThumbnailUrl(image);

            embed.WithDescription(
                $"**Type:** {poke.Type}\n\n" +
                $"{poke.Classification} Pokémon\n\n" +
                $"**HP:** {stats.HP}\n" +
                $"**Attack:** {stats.Attack}\n" +
                $"**Defense:** {stats.Defense}\n" +
                $"**Special Attack:** {stats.Special_Attack}\n" +
                $"**Special Defense:** {stats.Special_Defense}\n" +
                $"**Speed:** {stats.Speed}"
                );

            return embed;
        }

        public static (Pokemon poke, PokemonStats stat) RandomPokemon()
        {
            var context = new AppDbContext();

            var rand = new Random();
            int index = rand.Next(context.Pokemon.Count()) + 1;

            var poke = GetPokemonByID(index);
            var stats = GetStatsById(poke.DexNr);

            return (poke, stats);
        }

        public static (Pokemon poke, PokemonStats stat) GetPokemon(string content)
        {
            Pokemon poke;

            if (content.All(Char.IsDigit))
                poke = GetPokemonByID(Convert.ToInt32(content));
            else
                poke = GetPokemonByName(content);

            if (poke is null)
                return (null, null);

            var stats = GetStatsById(poke.DexNr);

            return (poke, stats);
        }

        public static Pokemon GetPokemonByID(int ID)
        {
            var context = new AppDbContext();
            return context.Pokemon.FirstOrDefault(p => p.DexNr == ID);
        }

        public static Pokemon GetPokemonByName(string name)
        {
            var context = new AppDbContext();
            return context.Pokemon.FirstOrDefault(p => p.Name.ToLower() == name.ToLower() || p.japName == name);
        }

        public static PokemonStats GetStatsById(int ID)
        {
            var context = new AppDbContext();
            return context.Stats.FirstOrDefault(s => s.PokemonNr == ID);
        }
    }
}
