using Splaak.Core.AbstractSyntax;

namespace Splaak.Core.Reader.Expressions
{
    /// <summary>
    /// Interface for all s-expressions.
    /// </summary>
    public interface ISExpression
    {
        /// <summary>
        /// Parses this s-expression.
        /// </summary>
        /// <returns>Abstract syntax-tree structure.</returns>
        IExprExt Parse();
    }
}
