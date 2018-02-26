using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BashSoft.Core.Contracts;
using BashSoft.StaticData;

namespace BashSoft.Core.Providers
{
    public class FileManager : IFileManager
    {
        public string CurrentDirectory
        {
            get => Directory.GetCurrentDirectory();
            set => Directory.SetCurrentDirectory(value);
        }

        public void OpenFile(string fileName)
        {
            var fullFilePath = string.Concat(this.CurrentDirectory, $"//{fileName}");
            Process.Start(fullFilePath);
        }

        public void CreateDirectory(string directoryName)
        {
            var fullDirectoryPath = string.Concat(this.CurrentDirectory, $"//{directoryName}");
            Directory.CreateDirectory(fullDirectoryPath);
        }
    }
}