using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

            embed.Description = commands;


            await ReplyAsync(embed: embed.Build());
        }
    }
}
