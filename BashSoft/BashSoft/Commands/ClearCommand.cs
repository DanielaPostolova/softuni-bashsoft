using System;
using System.Collections.Generic;
using System.IO;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;
using BashSoft.Core.Providers;
using BashSoft.StaticData;

namespace BashSoft.Commands
{
    public class ClearCommand : ICommand
    {
        private readonly IFileManager fileManager;

        public ClearCommand(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public string Execute(IList<string> commandParameters)
        {
            try
            {
                this.fileManager.ClearConsole();
                return string.Empty;
            }
            catch (IOException)
            {
                throw new InvalidOperationException(Constants.CannotClearConsoleErrorMessage);
            }
        }
    }
}