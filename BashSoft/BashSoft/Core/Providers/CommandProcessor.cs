using System;
using System.Collections.Generic;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;

namespace BashSoft.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        public string Process(ICommand command, IList<string> commandParameters)
        {
            var commandResult = command.Execute(commandParameters);
            return commandResult;
        }
    }
}