namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Exception for when parsing the program goes wrong.
    /// </summary>
    /// <seealso cref="SplaakException" />
    public class ParseException : SplaakException
    {
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
