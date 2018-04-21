using System;
using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents an integer in abstract syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class IntExt : IExprExt
    {
        /// <summary>
        /// The integer value of this abstract expression.
        /// </summary>
        public readonly int Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntExt"/> class.
        /// </summary>
        /// <param name="value">The integer value of this abstract expression.</param>
        public IntExt(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        public IExprC Desugar()
        {
            throw new NotImplementedException();
        }

        public override string ToString() => string.Format("IntExt({0})", Value);
    }
}
