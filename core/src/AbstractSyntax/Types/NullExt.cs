﻿using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.Types;

namespace Splaak.Core.AbstractSyntax.Types
{
    /// <summary>
    /// Represents a null value in abstract syntax.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class NullExt : IExprExt
    {
        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public ExprC Desugar() => new NullC();

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => "NullExt()";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is NullExt;

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => GetType().GetHashCode();
    }
}
