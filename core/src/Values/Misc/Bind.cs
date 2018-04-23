namespace Splaak.Core.Values.Misc
{
    /// <summary>
    /// Represents an environment bind.
    /// </summary>
    public class Bind
    {

        /// <summary>
        /// The value of this bind.
        /// </summary>
        public Value Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bind"/> class.
        /// </summary>
        /// <param name="value">The value of the bind.</param>
        public Bind(Value value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Bind({Value})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj) => obj is Bind that && Value.Equals(that.Value);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => GetType().GetHashCode() * Value.GetHashCode();
    }
}
