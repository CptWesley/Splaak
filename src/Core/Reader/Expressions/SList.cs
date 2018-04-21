using Splaak.Core.AbstractSyntax;

namespace Splaak.Core.Reader.Expressions
{
    /// <summary>
    /// Represents a list of S-expressions.
    /// </summary>
    /// <seealso cref="Splaak.Core.Reader.Expressions.ISExpression" />
    public class SList : ISExpression
    {
        /// <summary>
        /// The s-expressions contained in this list.
        /// </summary>
        public readonly ISExpression[] Expressions;

        /// <summary>
        /// Initializes a new instance of the <see cref="SList"/> class.
        /// </summary>
        /// <param name="expressions">The expressions contained in this list.</param>
        public SList(ISExpression[] expressions)
        {
            Expressions = expressions;
        }

        /// <summary>
        /// Parses this s-expression.
        /// </summary>
        /// <returns>
        /// Abstract syntax-tree structure.
        /// </returns>
        public IExprExt Parse()
        {
            throw new System.NotImplementedException();
        }
    }
}
