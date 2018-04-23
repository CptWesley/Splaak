namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Exception for when desugaring the program goes wrong.
    /// </summary>
    /// <seealso cref="SplaakException" />
    public class DesugarException : SplaakException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesugarException"/> class.
        /// </summary>
        public DesugarException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DesugarException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public DesugarException(string message) : base(message) { }
    }
}
