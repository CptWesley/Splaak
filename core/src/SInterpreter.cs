using Splaak.Core.Reader;
using Splaak.Core.Values;

namespace Splaak.Core
{
    /// <summary>
    /// Reads, parses, desugars and interprets input.
    /// </summary>
    public static class SInterpreter
    {
        /// <summary>
        /// Interprets the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The interpreted input.</returns>
        public static Value Interpret(this string input)
        {
            return input.Read().Parse().Desugar().Interpret().Force();
        }
    }
}
