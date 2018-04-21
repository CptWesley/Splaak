using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a subtraction.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class BinMinExt : IExprExt
    {
        /// <summary>
        /// The arguments for the subtraction.
        /// </summary>
        public readonly IExprExt Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinMinExt"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of the subtraction.</param>
        /// <param name="arg2">The right argument of the subtraction.</param>
        public BinMinExt(IExprExt arg1, IExprExt arg2)
        {
            Argument1 = arg1;
            Argument2 = arg2;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            return new PlusC(Argument1.Desugar(), new MultC(new IntC(-1), Argument2.Desugar()));
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("BinMinExt({0}, {1})", Argument1.ToString(), Argument2.ToString());
    }
}
