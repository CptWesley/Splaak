using System;

namespace Splaak.Core.Reader
{
    /// <summary>
    /// Exception for when reading the program goes wrong.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ReaderException : Exception {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReaderException"/> class.
        /// </summary>
        public ReaderException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReaderException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ReaderException(string message) : base(message) { }
    }
}
