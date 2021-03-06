﻿using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.Misc;

namespace Splaak.Core.AbstractSyntax.Misc
{
    /// <summary>
    /// Represents an if-statement.
    /// </summary>
    /// <seealso cref="IExprExt" />
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
        public ExprC Desugar()
        {
            return new IfC(Condition.Desugar(), Then.Desugar(), Else.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"IfExt({Condition}, {Then}, {Else})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is IfExt that)
            {
                return that.Condition.Equals(Condition) &&
                    that.Then.Equals(Then) &&
                    that.Else.Equals(Else);
            }
            return false;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return GetType().GetHashCode() *
                Condition.GetHashCode() *
                Then.GetHashCode() ^ 2 *
                Else.GetHashCode() ^ 3;
        }
    }
}
