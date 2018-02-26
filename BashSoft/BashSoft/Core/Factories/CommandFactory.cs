using Autofac;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;

namespace BashSoft.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IComponentContext componentContext;

        public CommandFactory(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }
        public ICommand Create(string commandName)
        {
            return this.componentContext.ResolveNamed<ICommand>(commandName);
        }
    }
}