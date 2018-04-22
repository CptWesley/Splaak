using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a float in abstract syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class FloatExt : IExprExt
    {
        /// <summary>
        /// The float value of this abstract expression.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatExt"/> class.
        /// </summary>
        /// <param name="value">The float value of this abstract expression.</param>
        public FloatExt(float value)
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
            return new FloatC(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("FloatExt({0})", Value);
    }
}
