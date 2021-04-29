using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeckoV2.Models;

namespace TreeckoV2.Commands
{
    public class Info : ModuleBase<SocketCommandContext>
    {
        [Command("Git")]
        public async Task GetGit() => await ReplyAsync("https://github.com/ScarredSceptile/TreeckoDiscordBot");


        [Group("Commands"), Alias("Help")]
        public class Help : ModuleBase<SocketCommandContext>
        {
            [Priority(1)]
            [Command("Pokemon"), Alias("Poke", "P")]
            public async Task HelpPokemon()
            {
                EmbedBuilder embed = new EmbedBuilder();
                embed.Title = "Pokemon Commands";

                string commands = "";

                commands += "**Pokemon** *{Name/ID}* - Get information about the pokemon";
                commands += "\n**Pokemon Random** - Get a random pokemon";
                commands += "\n**Pokemon EqualStats** *{amount} {name length}* - Get all pokemon with *{amount}* equal stats";
                commands += "\n**Pokemon Classification {classification} - Get all pokemon with classification**";
                commands += "\n**Pokemon IncompleteName** {name} - Gets all pokemon the name fits. Requires adding all blanks!";
                commands += "\n**Pokemon Weight** {name} - Gets all pokemon by Weight";
                commands += "\n**Pokemon Height** {name} - Gets all pokemon by Height";
                commands += "\n**Pokemon Shiny** - Add the shiny to get the shiny image. Works with random and *{Name/ID}*";

                embed.Description = commands;

                await ReplyAsync(embed: embed.Build());
            }

            [Command()]
            public async Task GetCommand()
            {
                EmbedBuilder embed = new EmbedBuilder();
                embed.Title = "Treecko Commands";

                string commands = "";

                commands += "**Say** - Repeats what you said";
                commands += "\n**Commands** - Gives this list";
                commands += "\n**Git** - Provides git repository with all published code";
                commands += "\n**SetPrefix** *{prefix}* - Changes prefix or resets with empty. Max 3 chars long";
                commands += "\n**GetPrefix** - Posts the current prefix for the server";
                commands += "\n**Pokemon** - Use \"Commands Pokemon\" for more info";

                embed.Description = commands;


                await ReplyAsync(embed: embed.Build());
            }
        }
        

        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("SetPrefix")]
        public async Task ResetPrefix()
        {
            ulong guildID = Context.Guild.Id;

            using (var context = new AppDbContext())
            {
                var guild = context.Guilds.FirstOrDefault(g => g.ID == guildID);

                SetPrefixDatabase(context, guild, guildID, "s-");
                await ReplyAsync("Prefix has been reset to s-");
            }
        }

        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("SetPrefix")]
        public async Task SetPrefix([Remainder] string prefix)
        {
            if (prefix.Length > 3)
            {
                await ReplyAsync("Prefix cannot be longer than 3 chars");
                return;
            }

            ulong guildID = Context.Guild.Id;

            using (var context = new AppDbContext())
            {
                var guild = context.Guilds.FirstOrDefault(g => g.ID == guildID);

                SetPrefixDatabase(context, guild, guildID, prefix);
                await ReplyAsync($"Prefix has been set to {prefix}");
            }
        }

        [Command("GetPrefix"), Alias("Prefix")]
        public async Task GetPrefix()
        {
            using (var context = new AppDbContext())
            {
                var guild = context.Guilds.FirstOrDefault(g => g.ID == Context.Guild.Id);

                if (guild is null)
                {
                    await ReplyAsync("The current prefix is s-");
                    return;
                }
                else
                {
                    await ReplyAsync($"The current prefix is {guild.Prefix}");
                }
            }
        }

        private void SetPrefixDatabase(AppDbContext context, DiscordGuild guild, ulong guildID, string prefix)
        {
            if (guild is null)
            {
                guild = new DiscordGuild
                {
                    ID = guildID,
                    Prefix = prefix
                };
                context.Guilds.Add(guild);
            }

            else
            {
                guild.Prefix = prefix;
            }

            context.SaveChanges();
        }
    }
}
