using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TreeckoV2.Discord
{
    public class Initialize
    {
        private readonly CommandService _commands;
        private readonly DiscordSocketClient _client;

        public Initialize(CommandService commands = null, DiscordSocketClient client = null)
        {
            _commands = commands ?? new CommandService();
            _client = client ?? new DiscordSocketClient();
        }

		public IServiceProvider BuildServiceProvider() => new ServiceCollection()
		.AddSingleton(_client)
		.AddSingleton(_commands)
		.AddSingleton<CommandHandler>()
		.BuildServiceProvider();
	}
}
