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

            int mostCommon = list.GroupBy(item => item)
                .Max(item => item.Count());

            return mostCommon;
        }

        public static EmbedBuilder PokeEmbed(Pokemon poke, PokemonStats stats, string image)
        {
            var embed = new EmbedBuilder();

            embed.WithAuthor($"{poke.DexNr}. {poke.Name}");
            embed.WithThumbnailUrl(image);

            embed.WithDescription(
                $"**Type:** {poke.Type}\n\n" +
                $"{poke.Classification}\n\n" +
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

            var poke = context.Pokemon.FirstOrDefault(p => p.DexNr == index);

            var stats = context.Stats.FirstOrDefault(s => s.PokemonNr == poke.DexNr);

            return (poke, stats);
        }

        public static (Pokemon poke, PokemonStats stat) GetPokemon(string content)
        {
            var context = new AppDbContext();
            Pokemon poke;

            if (content.All(Char.IsDigit))
            {
                Console.WriteLine("Content is Digit");
                poke = GetPokemonByID(Convert.ToInt32(content));
            }

            else
            {
                Console.WriteLine("Content is a string");
                poke = GetPokemonByName(content);
            }

            if (poke is null)
                return (null, null);

            Console.WriteLine($"Finding stats with {poke.DexNr}");
            var stats = context.Stats.FirstOrDefault(s => s.PokemonNr == poke.DexNr);

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
    }
}
