using System;
using Splaak.Core.Reader.Expressions;

namespace Splaak.Core.Reader
{
    /// <summary>
    /// Class used for reading Splaak code.
    /// </summary>
    public static class Reader
    {
        /// <summary>
        /// Reads the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>S-expression presented in the input.</returns>
        public static ISExpression Read(string input)
        {
            return Read(input, 0);
        }

        private static ISExpression Read(string input, int position)
        {
            throw new NotImplementedException();
        }
    }
}
