﻿using System;
using System.Collections.Generic;
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

        public IEnumerable<string> GetDirectoryContent(string directoryPath)
        {
            return Directory.GetDirectories(directoryPath)
                .Concat(Directory.GetFiles(directoryPath));
        }

        public bool IsDirectory(string directotyPath)
        {
            return Directory.Exists(directotyPath);
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}