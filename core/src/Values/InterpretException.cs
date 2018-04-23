namespace Splaak.Core.Values
{
    /// <summary>
    /// Exception for when interpreting the program goes wrong.
    /// </summary>
    /// <seealso cref="SplaakException" />
    public class InterpretException : SplaakException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InterpretException"/> class.
        /// </summary>
        public InterpretException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InterpretException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public InterpretException(string message) : base(message) { }
    }
}
