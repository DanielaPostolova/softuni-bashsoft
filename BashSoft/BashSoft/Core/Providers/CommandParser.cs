using System;
using System.Collections.Generic;
using System.Linq;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private readonly ICommandFactory commandFactory;

        public CommandParser(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }
        public ICommand Parse(string commandLine)
        {
            try
            {
                var commandName = this.SplitCommandInput(commandLine)[0];
                var command = this.commandFactory.Create(commandName);

                return command;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.InvalidCommandErrorMessage);
            }
        }

        public IList<string> ParseParameters(string commandLine)
        {
            return this.SplitCommandInput(commandLine).Skip(1).ToList();
        }

        private IList<string> SplitCommandInput(string commandLine)
        {
            return commandLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}