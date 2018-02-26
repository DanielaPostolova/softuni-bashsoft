namespace BashSoft.Core.Contracts
{
    public interface IFileManager
    {
        string CurrentDirectory { get; set; }

        void OpenFile(string fileName);

        void CreateDirectory(string directoryName);
    }
}