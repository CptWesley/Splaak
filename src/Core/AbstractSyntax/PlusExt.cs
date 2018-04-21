using System;
using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents an addition.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class PlusExt : IExprExt
    {
        /// <summary>
        /// The arguments for the addition.
        /// </summary>
        public readonly IExprExt Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlusExt"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of the addition.</param>
        /// <param name="arg2">The right argument of the addition.</param>
        public PlusExt(IExprExt arg1, IExprExt arg2)
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
        public override string ToString() => string.Format("PlusExt({0}, {1})", Argument1.ToString(), Argument2.ToString());
    }
}
