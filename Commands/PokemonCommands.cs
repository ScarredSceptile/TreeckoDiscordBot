using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeckoV2.Models;
using TreeckoV2.Utility;

namespace TreeckoV2.Commands
{
    [Group("Pokemon"), Alias("Poke", "P")]
    public class PokemonCommands : ModuleBase<SocketCommandContext>
    {
        [Group("Shiny"), Alias("S")]
        public class Shiny : ModuleBase<SocketCommandContext>
        {
            [Priority(1)]
            [Command("Random"), Alias("R")]
            public async Task RandomShiny()
            {
                using (var context = new AppDbContext())
                {
                    var poke = PokemonUtility.RandomPokemon();

                    if (poke.poke is null || poke.stat is null)
                    {
                        await ReplyAsync("Unable to find Random Pokemon with Stats");
                        return;
                    }

                    var embed = PokemonUtility.PokeEmbed(poke.poke, poke.stat, poke.poke.PicShiny);

                    await ReplyAsync(embed: embed.Build());
                }
            }

            [Command]
            public async Task ShinyPoke(string content = "")
            {
                if (content == "")
                {
                    await ReplyAsync("Please provide either an ID or Name of a pokemon");
                    return;
                }

                var shiny = PokemonUtility.GetPokemon(content);

                if (shiny.poke is null || shiny.stat is null)
                {
                    await ReplyAsync($"Unable to find Pokemon by {content}");
                    return;
                }

                var embed = PokemonUtility.PokeEmbed(shiny.poke, shiny.stat, shiny.poke.PicShiny);

                await ReplyAsync(embed: embed.Build());
            }
        }

        [Command("IncompleteName"), Alias("IN")]
        public async Task IncompleteName(string name)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int index = 0;
            int length = name.Length;

            foreach (char ch in name)
            {
                if (char.IsLetter(ch))
                {
                    dict.Add(ch, index);
                }
                index++;
            }

            var pokes = PokemonUtility.GetPokemonByIncompleteName(dict, length);
            await PostList(pokes, $"{name}");
        }

        [Command("EqualStats"), Alias("ES")]
        public async Task EqualStats(int total, int length = 0)
        {
            if (total < 2 || total > 6)
            {
                await ReplyAsync("Please provie a total between 2 and 6, including 2 and 6");
                return;
            }

            var pokes = PokemonUtility.GetPokemonEqualStats(total, length);

            await PostList(pokes, $"{total} equal stats and name length of {length}");
        }

        [Command("EqualStats"), Alias("ES")]
        public async Task EqualStatsAll(int total)
        {
            if (total < 2 || total > 6)
            {
                await ReplyAsync("Please provie a total between 2 and 6, including 2 and 6");
                return;
            }

            var pokes = PokemonUtility.GetPokemonEqualStats(total, 0);

            await PostList(pokes, $"{total} equal stats");
        }

        [Command("Classification"), Alias("C")]
        public async Task PokemonByClassification([Remainder]string classification)
        {
            var context = new AppDbContext();

            var pokes = context.Pokemon.AsQueryable().Where(p => p.Classification.ToLower().Contains(classification.ToLower())).ToList();

            await PostList(pokes, $"{classification} classification");
        }

        [Priority(1)]
        [Command("Random"), Alias("R")]
        public async Task RandomPoke()
        {
            using (var context = new AppDbContext())
            {
                var poke = PokemonUtility.RandomPokemon();

                if (poke.poke is null || poke.stat is null)
                {
                    await ReplyAsync("Unable to find Random Pokemon with Stats");
                    return;
                }

                var embed = PokemonUtility.PokeEmbed(poke.poke, poke.stat, poke.poke.Pic);

                await ReplyAsync(embed: embed.Build());
            }
        }

        [Command]
        public async Task Poke(string content = "")
        {
            if (content == "")
            {
                await ReplyAsync("Please provide either an ID or Name of a pokemon");
                return;
            }

            Console.WriteLine("Finding pokemon");

            var poke = PokemonUtility.GetPokemon(content);

            Console.WriteLine("Pokemon Found");

            if (poke.poke is null || poke.stat is null)
            {
                await ReplyAsync($"Unable to find Pokemon by {content}");
                return;
            }

            var embed = PokemonUtility.PokeEmbed(poke.poke, poke.stat, poke.poke.Pic);

            await ReplyAsync(embed: embed.Build());
        }

        public async Task PostList(List<Pokemon> pokes, string content)
        {
            string allPoke = "";

            foreach (var poke in pokes)
            {
                //DO not get any messages longer than 2k!
                if (allPoke.Count() + poke.Name.Count() > 2000)
                {
                    await ReplyAsync(allPoke);
                    allPoke = "";
                }

                allPoke += poke.Name + '\n';
            }

            if (allPoke.Length == 0)
            {
                await ReplyAsync($"Unable to find any pokemon with {content}");
                return;
            }

            await ReplyAsync(allPoke);
        }
    }
}
