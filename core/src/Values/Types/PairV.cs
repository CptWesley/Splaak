namespace Splaak.Core.Values.Types
{
    /// <summary>
    /// Represents a pair.
    /// </summary>
    /// <seealso cref="Value" />
    public class PairV : Value
    {
        /// <summary>
        /// The members of the pair.
        /// </summary>
        public readonly Value Left, Right;

        /// <summary>
        /// Initializes a new instance of the <see cref="PairV"/> class.
        /// </summary>
        /// <param name="left">The left element of the pair.</param>
        /// <param name="right">The right element of the pair.</param>
        public PairV(Value left, Value right)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Forces this value to compute all thunks recursively.
        /// </summary>
        /// <returns>
        /// The fully computed variant of this value.
        /// </returns>
        public override Value Force() => new PairV(Left.Force(), Right.Force());

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"PairV({Left}, {Right})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is PairV that)
            {
                return that.Left.Equals(Left) && that.Right.Equals(Right);
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
            return GetType().GetHashCode() * Left.GetHashCode() * Right.GetHashCode() ^ 2;
        }
    }
}
