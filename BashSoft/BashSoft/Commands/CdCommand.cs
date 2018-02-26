using System;
using System.Collections.Generic;
using System.IO;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Commands
{
    public class CdCommand : ICommand
    {
        private readonly IFileManager fileManager;

        public CdCommand(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }
        public string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null) throw new ArgumentNullException();
            if (commandParameters.Count == 0) throw new ArgumentException();

            string relativePath = commandParameters[0];

            try
            {
                if (relativePath == "..")
                {
                    int indexOfLastSlash = this.fileManager.CurrentDirectory
                        .LastIndexOf("\\", StringComparison.Ordinal);

                    string newPath = this.fileManager.CurrentDirectory
                        .Substring(0, indexOfLastSlash);

                    this.fileManager.CurrentDirectory = newPath;
                }
                else
                {
                    string currenPath = this.fileManager.CurrentDirectory;
                    currenPath += "\\" + relativePath;
                    this.fileManager.CurrentDirectory = currenPath;
                }
            }
            catch (Exception)
            {
                throw new DirectoryNotFoundException(string.Format(Constants.DirectoryCannotOpenErrorMessage, relativePath));
            }

            return string.Format(Constants.DiretoryChangedSuccessMessage, fileManager.CurrentDirectory);
        }

    }
}
