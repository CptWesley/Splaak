﻿using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a multiplication.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class MultExt : IExprExt
    {
        /// <summary>
        /// The arguments for the multiplication.
        /// </summary>
        public readonly IExprExt Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlusExt"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of the multiplication.</param>
        /// <param name="arg2">The right argument of the multiplication.</param>
        public MultExt(IExprExt arg1, IExprExt arg2)
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
            return new MultC(Argument1.Desugar(), Argument2.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("MultExt({0}, {1})", Argument1.ToString(), Argument2.ToString());
    }
}
