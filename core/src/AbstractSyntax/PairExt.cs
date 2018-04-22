using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a pair.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class PairExt : IExprExt
    {
        /// <summary>
        /// The elements of the pair.
        /// </summary>
        public readonly IExprExt Left, Right;

        /// <summary>
        /// Initializes a new instance of the <see cref="PairExt"/> class.
        /// </summary>
        /// <param name="left">The left element of the pair.</param>
        /// <param name="right">The right element of the pair.</param>
        public PairExt(IExprExt left, IExprExt right)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            return new PairC(Left.Desugar(), Right.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"PairExt({Left}, {Right})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is PairExt that)
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
