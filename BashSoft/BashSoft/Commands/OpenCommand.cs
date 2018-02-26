using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autofac;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Commands
{
    public class OpenCommand : ICommand
    {
        private readonly IFileManager fileManager;

        public OpenCommand(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null) throw new ArgumentNullException();
            if (commandParameters.Count == 0) throw new ArgumentException();

            var fileName = commandParameters[0];

            try
            {
                this.fileManager.OpenFile(fileName);
            }
            catch (Exception)
            {
                throw new InvalidOperationException(string.Format(Constants.FileCannotOpenErrorMessage, fileName));
            }

            return string.Format(Constants.FileOpenedSuccessMessage, fileName);
        }
    }
}