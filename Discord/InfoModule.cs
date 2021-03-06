using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeckoV2.Discord
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
		// ~say hello world -> hello world
		[Command("say")]
		[Summary("Echoes a message.")]
		public async Task SayAsync([Remainder][Summary("The text to echo")] string echo)
        {
			await Context.Message.DeleteAsync();

			await ReplyAsync (echo);
		}

		// ReplyAsync is a method on ModuleBase 
	}
}
