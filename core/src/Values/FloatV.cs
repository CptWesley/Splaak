using System;

namespace Splaak.Core.Values
{
    /// <summary>
    /// Represents a float.
    /// </summary>
    /// <seealso cref="Splaak.Core.Values.IValue" />
    public class FloatV : IValue
    {
        /// <summary>
        /// The float value.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatV"/> class.
        /// </summary>
        /// <param name="value">The float value.</param>
        public FloatV(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("FloatV({0})", Value);

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is FloatV)
            {
                return Math.Abs(((FloatV) obj).Value - Value) < 0.001;
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
