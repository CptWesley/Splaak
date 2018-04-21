﻿using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents an if-statement.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class IfExt : IExprExt
    {
        /// <summary>
        /// The arguments for if-statement.
        /// </summary>
        public readonly IExprExt Condition, Then, Else;

        /// <summary>
        /// Initializes a new instance of the <see cref="IfExt"/> class.
        /// </summary>
        /// <param name="condition">The condition of the if-statement.</param>
        /// <param name="then">The path taken when the condition is true.</param>
        /// <param name="els">The path taken when the condition is false.</param>
        public IfExt(IExprExt condition, IExprExt then, IExprExt els)
        {
            Condition = condition;
            Then = then;
            Else = els;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            return new IfC(Condition.Desugar(), Then.Desugar(), Else.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("IfExt({0}, {1}, {2})",
            Condition.ToString(),
            Then.ToString(),
            Else.ToString());
    }
}