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
    }
}
