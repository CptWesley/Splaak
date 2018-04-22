using Splaak.Core.AbstractSyntax;

namespace Splaak.Core.Reader.Expressions
{
    /// <summary>
    /// Represents a float.
    /// </summary>
    /// <seealso cref="Splaak.Core.Reader.Expressions.ISExpression" />
    public class SFloat : ISExpression
    {
        /// <summary>
        /// The value of the expression.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SFloat"/> class.
        /// </summary>
        /// <param name="value">The value of the expression.</param>
        public SFloat(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Parses this s-expression.
        /// </summary>
        /// <returns>
        /// Abstract syntax-tree structure.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IExprExt Parse()
        {
            return new FloatExt(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("SFloat({0})", Value);
    }
}
