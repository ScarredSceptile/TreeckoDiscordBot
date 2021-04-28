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

        [Command("Commands"), Alias("Help")]
        public async Task GetCommand()
        {
            EmbedBuilder embed = new EmbedBuilder();
            embed.Title = "Treecko Commands";

            string commands = "";

            commands += "Say - Repeats what you said";
            commands += "\nCommands - Gives this list";
            commands += "\nGit - Provides git repository with all published code";
            commands += "\nSetPrefix {prefix} - Changes prefix or resets with empty. Max 3 chars long";

            embed.Description = commands;


            await ReplyAsync(embed: embed.Build());
        }

        [Command("SetPrefix"), Alias("Prefix")]
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

        [Command("SetPrefix"), Alias("Prefix")]
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
