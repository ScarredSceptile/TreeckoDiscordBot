using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using TreeckoV2.Discord;
using TreeckoV2.Models;

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
            _client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Debug });
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

            _client.JoinedGuild += JoinedGuild;

            _client.Ready += () =>
            {
                Console.WriteLine("Bot is connected!");
                return Task.CompletedTask;
            };

            await Task.Delay(-1);
        }

        private async Task JoinedGuild(SocketGuild guild)
        {
            ulong guildID = guild.Id;

            using (var context = new AppDbContext())
            {
                if (context.Guilds.FirstOrDefault(g => g.ID == guildID) is null)
                {
                    DiscordGuild newGuild = new DiscordGuild
                    {
                        ID = guildID,
                        Prefix = "s-"
                    };
                    context.Guilds.Add(newGuild);
                }
                await context.SaveChangesAsync();
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private string GetToken()
        {
#if DEBUG
            var file = @"D:\Treecko\TreeckoV2\TreeckoV2\Data\Token.txt";
#else
            var file = @"D:\Treecko\Data\Token.txt";
#endif

            return File.ReadAllText(file);
        }
    }
}
