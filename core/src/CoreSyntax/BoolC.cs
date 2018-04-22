using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents a boolean in core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class BoolC : IExprC
    {
        /// <summary>
        /// The boolean value of this core expression.
        /// </summary>
        public readonly bool Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolC"/> class.
        /// </summary>
        /// <param name="value">The boolean value of this core expression.</param>
        public BoolC(bool value)
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
            return new BoolV(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("BoolC({0})", Value);
    }
}
