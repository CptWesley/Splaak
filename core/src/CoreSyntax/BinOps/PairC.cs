using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax.BinOps
{
    /// <summary>
    /// Represents a pair in core syntax.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class PairC : ExprC
    {
        /// <summary>
        /// The elements of the pair.
        /// </summary>
        public readonly ExprC Left, Right;

        /// <summary>
        /// Initializes a new instance of the <see cref="PairC"/> class.
        /// </summary>
        /// <param name="left">The left argument of this pair.</param>
        /// <param name="right">The right argument of this pair.</param>
        public PairC(ExprC left, ExprC right)
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
        public override IValue Interpret(Environment env)
        {
            return new PairV(Left.Interpret(env), Right.Interpret(env));
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"PairC({Left}, {Right})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is PairC that)
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
