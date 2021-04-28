using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TreeckoV2.Commands;
using TreeckoV2.Models;

namespace TreeckoV2.Discord
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;

        public CommandHandler(DiscordSocketClient client, CommandService commands)
        {
            _client = client;
            _commands = commands;
        }

        public async Task InstallCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            _commands.AddTypeReader(typeof(bool), new TypeReaders.BooleanTypeReader());
            _commands.AddTypeReader(typeof(int), new TypeReaders.IntegerTypeReader());

            await _commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);
        }

        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null) return;


            //Use message.content for general command stuff

            int argPos = 0;

            string prefix;

            var channel = message.Channel as SocketGuildChannel;

            var guildID = channel.Guild.Id;

            var db = new AppDbContext();
            var currentGuild = db.Guilds.FirstOrDefault(g => g.ID == guildID);

            if (currentGuild is null)
                prefix = "s-";
            else
                prefix = currentGuild.Prefix;

            if (!(message.HasStringPrefix(prefix, ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
            {
                return;
            }

            var context = new SocketCommandContext(_client, message);

            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }
    }
}
