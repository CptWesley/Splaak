using System;

namespace Splaak.Core
{
    /// <summary>
    /// Exception for when something splaak related goes wrong.
    /// </summary>
    /// <seealso cref="Exception" />
    public abstract class SplaakException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplaakException"/> class.
        /// </summary>
        protected SplaakException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SplaakException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        protected SplaakException(string message) : base(message) { }
    }
}
