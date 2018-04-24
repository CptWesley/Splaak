using Splaak.Core.Values;
using Splaak.Core.Values.Misc;

namespace Splaak.Core.CoreSyntax.Misc
{
    /// <summary>
    /// Represents a sequence in core syntax.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class SeqC : ExprC
    {
        /// <summary>
        /// The elements of the pair.
        /// </summary>
        public readonly ExprC Left, Right;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeqC"/> class.
        /// </summary>
        /// <param name="left">The left argument of this sequence.</param>
        /// <param name="right">The right argument of this sequence.</param>
        public SeqC(ExprC left, ExprC right)
        {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Interprets this core expression with an environment.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <returns>
        /// Resulting value.
        /// </returns>
        public override Value Interpret(Environment env)
        {
            Left.Interpret(env);
            return Right.Interpret(env);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SeqC({Left}, {Right})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SeqC that)
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
