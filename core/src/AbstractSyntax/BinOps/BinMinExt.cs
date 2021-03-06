﻿using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.BinOps;
using Splaak.Core.CoreSyntax.Types;

namespace Splaak.Core.AbstractSyntax.BinOps
{
    /// <summary>
    /// Represents a subtraction.
    /// </summary>
    /// <seealso cref="IExprExt" />
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
        public ExprC Desugar()
        {
            return new PlusC(Argument1.Desugar(), new MultC(new IntC(-1), Argument2.Desugar()));
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"BinMinExt({Argument1}, {Argument2})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is BinMinExt that)
            {
                return that.Argument1.Equals(Argument1) && that.Argument2.Equals(Argument2);
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
            return GetType().GetHashCode() * Argument1.GetHashCode() * Argument2.GetHashCode() ^ 2;
        }
    }
}
