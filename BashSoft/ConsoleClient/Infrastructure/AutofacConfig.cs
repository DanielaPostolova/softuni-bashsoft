using System;
using System.Linq;
using System.Reflection;
using Autofac;
using BashSoft.Commands;
using BashSoft.Commands.Contracts;
using BashSoft.Core;
using BashSoft.Core.Contracts;
using BashSoft.Core.Factories;
using BashSoft.Core.Providers;

namespace ConsoleClient.Infrastructure
{
    public class AutofacConfig
    {
        private IContainer container;

        public IContainer Container
        {
            get
            {
                if (container == null)
                {
                    throw new InvalidOperationException();
                }
                return this.container;
            }
        }

        public void Config()
        {
            var builder = new ContainerBuilder();

            RegisterCoreComponents(builder);
            RegisterDynamicCommands(builder);

            this.container = builder.Build();
        }

        private static void RegisterDynamicCommands(ContainerBuilder builder)
        {
            var assembly = Assembly.GetAssembly(typeof(ICommand));

            var types = assembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)) && !type.IsAbstract)
                .ToList();

            foreach (var type in types)
            {
                var commandName = type.Name.ToLowerInvariant().Replace("command", string.Empty);
                builder.RegisterType(type.AsType()).Named<ICommand>(commandName);
            }
        }

        private void RegisterCoreComponents(ContainerBuilder builder)
        {
            var assembly = Assembly.GetAssembly(typeof(IEngine));

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().SingleInstance();
        }
    }
}