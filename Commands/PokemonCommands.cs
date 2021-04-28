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

        [NamedArgumentType]
        public class EqualStatsNameableArguments
        {
            public int Total { get; set; }
            public int NameLength { get; set; }
        }

        [Command("EqualStats"), Alias("ES")]
        public async Task EqualStats(int total, int length)
        {
            var context = new AppDbContext();
            if (total < 2 || total > 6)
            {
                await ReplyAsync("Please provie a number between 2 and 6, including 2 and 6");
                return;
            }

            var allPokes = context.Pokemon.ToList();

            List<Pokemon> pokes = new List<Pokemon>();

            foreach(var poke in allPokes)
            {
                if (poke.Name.Length != length)
                    continue;

                var stats = context.Stats.AsQueryable().Where(s => s.PokemonNr == poke.DexNr).ToList();

                foreach (var stat in stats)
                {
                    if (PokemonUtility.EqualStatsAmount(stat) == total && !pokes.Contains(poke))
                        pokes.Add(poke);
                }
            }

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

            await ReplyAsync(allPoke);
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
    }
}
