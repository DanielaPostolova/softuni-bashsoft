using BashSoft.Commands.Contracts;

namespace BashSoft.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandName);
    }
}