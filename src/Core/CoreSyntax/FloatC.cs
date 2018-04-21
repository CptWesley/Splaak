using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents a float in core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class FloatC : IExprC
    {
        /// <summary>
        /// The float value of this core expression.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatC"/> class.
        /// </summary>
        /// <param name="value">The float value of this core expression.</param>
        public FloatC(float value)
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
            return new FloatV(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("FloatC({0})", Value);
    }
}
