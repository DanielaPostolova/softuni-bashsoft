using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BashSoft.Commands.Contracts;
using BashSoft.Core.Contracts;
using BashSoft.Core.Providers;
using BashSoft.StaticData;

namespace BashSoft.Commands
{
    public class LsCommand : ICommand
    {
        private readonly IFileManager fileManager;

        public LsCommand(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public string Execute(IList<string> commandParameters)
        {
            try
            {
                var resultBuilder = new StringBuilder();
                var depth = commandParameters.Count == 0 ? 0 : uint.Parse(commandParameters[0]);

                TraverseDirectory(depth, this.fileManager.CurrentDirectory, resultBuilder);
                return resultBuilder.ToString().TrimEnd();
            }
            catch (Exception)
            {
                throw new ArgumentException(Constants.InvalidCommandParametersErrorMessage);
            }
        }

        private void TraverseDirectory(long depth, string currentPath, StringBuilder builder, int identation = 0)
        {
            if (depth < 0)
            {
                return;
            }

            var directoryContent = this.fileManager.GetDirectoryContent(currentPath);

            foreach (string contentElement in directoryContent)
            {
                if (this.fileManager.IsDirectory(contentElement))
                {
                    builder.AppendLine(
                        $"{new string('-', identation)}{contentElement.Substring(currentPath.Length)}");
                    TraverseDirectory(depth - 1, contentElement, builder, identation + 10);
                }
                else
                {
                    string fileName = contentElement.Substring(currentPath.Length);
                    builder.AppendLine($"{new string('-', identation)}{fileName}");
                }
            }
        }
    }
}