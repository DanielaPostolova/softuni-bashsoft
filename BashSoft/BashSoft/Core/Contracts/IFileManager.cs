using System.Collections.Generic;

namespace BashSoft.Core.Contracts
{
    public interface IFileManager
    {
        string CurrentDirectory { get; set; }

        void OpenFile(string fileName);

        void CreateDirectory(string directoryName);

        IEnumerable<string> GetDirectoryContent(string directoryPath);

        bool IsDirectory(string directotyPath);
    }
}