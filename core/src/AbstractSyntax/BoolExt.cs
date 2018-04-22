using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a boolean value.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class BoolExt : IExprExt
    {
        /// <summary>
        /// The boolean value of this abstract syntax expression.
        /// </summary>
        public readonly bool Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolExt"/> class.
        /// </summary>
        /// <param name="value">The boolean value of this abstract syntax expression.</param>
        public BoolExt(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            return new BoolC(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("BoolExt({0})", Value);
    }
}
