
using System;
using BashSoft.Core.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser commandParser;
        private readonly ICommandProcessor commandProcessor;
        private readonly IConsoleRenderer consoleRenderer;
        private readonly IFileManager fileManager;

        public Engine(ICommandParser commandParser, ICommandProcessor commandProcessor, IConsoleRenderer consoleRenderer, IFileManager fileManager)
        {
            this.commandParser = commandParser;
            this.commandProcessor = commandProcessor;
            this.consoleRenderer = consoleRenderer;
            this.fileManager = fileManager;
        }

        public void Start()
        {
            while (true)
            {
                this.consoleRenderer.Write($"{this.fileManager.CurrentDirectory}$ ", ConsoleColor.DarkBlue);
                var commandLine = this.consoleRenderer.ReadLine();

                if (commandLine == Constants.QuitCommand) break;
                
                try
                {
                    var command = this.commandParser.Parse(commandLine);
                    var commandParameters = this.commandParser.ParseParameters(commandLine);
                    var commandResult = this.commandProcessor.Process(command, commandParameters);

                    this.consoleRenderer.WriteLine(commandResult);
                }
                catch (Exception e)
                {
                    this.consoleRenderer.WriteLine(e.Message, ConsoleColor.Red);
                }
            }
        }
    }
}