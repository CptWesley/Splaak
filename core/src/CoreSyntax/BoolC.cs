﻿using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents a boolean in core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class BoolC : IExprC
    {
        /// <summary>
        /// The boolean value of this core expression.
        /// </summary>
        public readonly bool Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoolC"/> class.
        /// </summary>
        /// <param name="value">The boolean value of this core expression.</param>
        public BoolC(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Interprets this core expression.
        /// </summary>
        /// <returns>
        /// Resulting value.
        /// </returns>
        public IValue Interpret()
        {
            return new BoolV(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"BoolC({Value})";

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is BoolC)
            {
                return ((BoolC) obj).Value == Value;
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
            return GetType().GetHashCode() * Value.GetHashCode();
        }
    }
}