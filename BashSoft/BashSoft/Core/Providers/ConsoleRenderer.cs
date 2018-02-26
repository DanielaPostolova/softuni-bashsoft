using System;
using BashSoft.Core.Contracts;

namespace BashSoft.Core.Providers
{
    public class ConsoleRenderer : IConsoleRenderer
    {
        private const ConsoleColor DefaultColor = ConsoleColor.White;
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public void WriteLine(object obj, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            this.WriteLine(obj);
            Console.ForegroundColor = DefaultColor;
        }

        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void Write(object obj, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            this.Write(obj);
            Console.ForegroundColor = DefaultColor;
        }
    }
}