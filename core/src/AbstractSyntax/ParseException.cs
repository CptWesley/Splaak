using System.Collections.Generic;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Exception for when parsing the program goes wrong.
    /// </summary>
    /// <seealso cref="SplaakException" />
    public class ParseException : SplaakException
    {
        /// <summary>
        /// The set of reserved symbols.
        /// </summary>
        public static readonly HashSet<string> ReservedSymbols = new HashSet<string>
        {
            "and", "or", "-", "+", "*", "/", "=", "<", "<=", ">", ">=", "pair", // BinOps
            "first", "second", "not", "-", "head", "tail", // UnOps
            "if", "tuple", "let", "set", "lambda", "seq", // Misc
            "this", "null" // Other
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ParseException"/> class.
        /// </summary>
        public ParseException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParseException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ParseException(string message) : base(message) { }
    }
}
