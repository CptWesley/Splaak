using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Interface for the core syntax.
    /// </summary>
    public interface IExprC
    {
        /// <summary>
        /// Interprets this core expression.
        /// </summary>
        /// <returns>Resulting value.</returns>
        IValue Interpret();
    }
}
