﻿namespace Splaak.Core.Values.Types
{
    /// <summary>
    /// Represents an integer.
    /// </summary>
    /// <seealso cref="Values.Value" />
    public class IntV : Value
    {
        /// <summary>
        /// The integer value.
        /// </summary>
        public readonly int Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntV"/> class.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public IntV(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"IntV({Value})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is IntV that)
            {
                return that.Value == Value;
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
