using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using TreeckoV2.Discord;

namespace TreeckoV2
{
    public class Program
    {
        private DiscordSocketClient _client;
        private CommandHandler _commandHandler;
        private CommandService _commandService;
        private LoggingService _loggingService;
        private Initialize _initialize;

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            var _config = new DiscordSocketConfig { MessageCacheSize = 100 };
            _client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Debug});
            _commandService = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = false,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });
            

            _client.Log += Log;

            string token = GetToken();

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            _loggingService = new LoggingService(_client, _commandService);
            _commandHandler = new CommandHandler(_client, _commandService);
            await _commandHandler.InstallCommandsAsync();
            _initialize = new Initialize(_commandService, _client);
            _initialize.BuildServiceProvider();

            _client.MessageUpdated += MessageUpdated;

            _client.Ready += () =>
            {
                Console.WriteLine("Bot is connected!");
                return Task.CompletedTask;
            };

            await Task.Delay(-1);
        }

        private async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message} → {after}");
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private string GetToken()
        {
            var file = @"D:\Treecko\TreeckoV2\TreeckoV2\Data\Token.txt";

            return File.ReadAllText(file);
        }

    }
}
