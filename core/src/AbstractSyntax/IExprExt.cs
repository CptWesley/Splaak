using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Interface for abstract syntax tree objects.
    /// </summary>
    public interface IExprExt
    {
        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>Core expression variant.</returns>
        ExprC Desugar();
    }
}
