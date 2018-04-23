using System;
using Splaak.Core;
using Splaak.Core.Values;

namespace Splaak.Repl
{
    /// <summary>
    /// REPL for the Splaak language.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry method of the program
        /// </summary>
        /// <param name="args">Program arguments.</param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("splaak> ");
                string input = Console.ReadLine();
                try
                {
                    Value result = SInterpreter.Interpret(input);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
