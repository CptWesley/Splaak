using System;
using Splaak.Core.AbstractSyntax;

namespace Splaak.Core.Reader.Expressions
{
    /// <summary>
    /// Represents a float.
    /// </summary>
    /// <seealso cref="Splaak.Core.Reader.Expressions.ISExpression" />
    public class SFloat : ISExpression
    {
        /// <summary>
        /// The value of the expression.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SFloat"/> class.
        /// </summary>
        /// <param name="value">The value of the expression.</param>
        public SFloat(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Parses this s-expression.
        /// </summary>
        /// <returns>
        /// Abstract syntax-tree structure.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IExprExt Parse()
        {
            return new FloatExt(Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SFloat({Value})";

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SFloat)
            {
                return Math.Abs(((SFloat) obj).Value - Value) < 0.001;
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
