using System;
using System.Collections.Generic;
using System.IO;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Commands
{
    public class MkdirCommand : ICommand
    {
        private readonly IFileManager fileManager;

        public MkdirCommand(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }
        public string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null) throw new ArgumentNullException();
            if (commandParameters.Count == 0) throw new ArgumentException();

            string directoryName = commandParameters[0];

            try
            {
                this.fileManager.CreateDirectory(directoryName);
            }
            catch (Exception)
            {
                throw new InvalidOperationException(string.Format(Constants.CannotCreateDirectoryErrorMessage, directoryName));
            }

            return string.Format(Constants.DirectoryCreatedSuccessMessage, directoryName);
        }
    }
}