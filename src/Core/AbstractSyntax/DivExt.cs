using System;
using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a division.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class DivExt : IExprExt
    {
        /// <summary>
        /// The arguments for the division.
        /// </summary>
        public readonly IExprExt Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivExt"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of the division.</param>
        /// <param name="arg2">The right argument of the division.</param>
        public DivExt(IExprExt arg1, IExprExt arg2)
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
        /// <exception cref="NotImplementedException"></exception>
        public IExprC Desugar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("DivExt({0}, {1})", Argument1.ToString(), Argument2.ToString());
    }
}
