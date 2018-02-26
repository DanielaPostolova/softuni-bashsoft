using System.Collections.Generic;

namespace BashSoft.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> commandParameters);
    }
}