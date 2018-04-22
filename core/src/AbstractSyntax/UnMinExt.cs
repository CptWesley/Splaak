using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a unary minus expression.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class UnMinExt : IExprExt
    {
        /// <summary>
        /// The argument of the unary minus expression.
        /// </summary>
        public readonly IExprExt Argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnMinExt"/> class.
        /// </summary>
        /// <param name="argument">The argument of the unary minus expression.</param>
        public UnMinExt(IExprExt argument)
        {
            Argument = argument;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            return new MultC(new IntC(-1), Argument.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("UnMinExt({0})", Argument.ToString());
    }
}
