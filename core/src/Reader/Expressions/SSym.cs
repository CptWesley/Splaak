using Splaak.Core.AbstractSyntax;

namespace Splaak.Core.Reader.Expressions
{
    /// <summary>
    /// Represents a symbol.
    /// </summary>
    public class SSym : ISExpression
    {
        /// <summary>
        /// The symbol of the expression.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SSym"/> class.
        /// </summary>
        /// <param name="value">The symbol of the expression.</param>
        public SSym(string value)
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
            switch (Value)
            {
                case "true":
                    return new BoolExt(true);
                case "false":
                    return new BoolExt(false);
                default:
                    throw new ParseException();
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("SSym({0})", Value);
    }
}
