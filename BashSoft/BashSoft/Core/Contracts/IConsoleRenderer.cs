using System;

namespace BashSoft.Core.Contracts
{
    public interface IConsoleRenderer
    {
        string ReadLine();
        void WriteLine(object obj);
        void WriteLine(object obj, ConsoleColor color);
        void Write(object obj);
        void Write(object obj, ConsoleColor color);
    }
}