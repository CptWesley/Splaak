using Splaak.Core.Reader;
using System;

namespace Splaak
{
    /// <summary>
    /// REPL class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Opens the REPL of Splaak.
        /// </summary>
        /// <param name="args">The arguments of running the application.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("(if true 5 0)".Execute());

            Console.ReadKey();
        }
    }
}
