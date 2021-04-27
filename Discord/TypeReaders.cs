using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeckoV2.Discord
{
    public class TypeReaders
    {
        public class BooleanTypeReader : TypeReader
        {
            public override Task<TypeReaderResult> ReadAsync(ICommandContext context, string input, IServiceProvider services)
            {
                bool result;
                if (bool.TryParse(input, out result))
                    return Task.FromResult(TypeReaderResult.FromSuccess(result));

                return Task.FromResult(TypeReaderResult.FromError(CommandError.ParseFailed, "Input could not be parsed as a boolean"));
            }
        }

        public class IntegerTypeReader : TypeReader
        {
            public override Task<TypeReaderResult> ReadAsync(ICommandContext context, string input, IServiceProvider services)
            {
                int result;
                if (int.TryParse(input, out result))
                    return Task.FromResult(TypeReaderResult.FromSuccess(result));

                return Task.FromResult(TypeReaderResult.FromError(CommandError.ParseFailed, "Input could not be parsed as an integer"));
            }
        }
    }
}
