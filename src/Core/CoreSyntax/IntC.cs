using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents an integer in core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class IntC : IExprC
    {
        /// <summary>
        /// The integer value of this abstract expression.
        /// </summary>
        public readonly int Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntC"/> class.
        /// </summary>
        /// <param name="value">The integer value of this core expression.</param>
        public IntC(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Interprets this core expression.
        /// </summary>
        /// <returns>
        /// Resulting value.
        /// </returns>
        public IValue Interpret()
        {
            return new IntV(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("IntC({0})", Value);
    }
}
