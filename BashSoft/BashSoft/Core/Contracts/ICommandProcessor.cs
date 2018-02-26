using System.Collections.Generic;
using BashSoft.Commands.Contracts;

namespace BashSoft.Core.Contracts
{
    public interface ICommandProcessor
    {
        string Process(ICommand command, IList<string> commandParameters);
    }
}