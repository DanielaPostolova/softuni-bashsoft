using System.Collections.Generic;
using BashSoft.Commands.Contracts;

namespace BashSoft.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand Parse(string commandLine);
        IList<string> ParseParameters(string commandLine);
    }
}