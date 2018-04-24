using System.Linq;
using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.Misc;

namespace Splaak.Core.AbstractSyntax.Misc
{
    /// <summary>
    /// Represents a sequence of operations.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class SeqExt : IExprExt
    {
        /// <summary>
        /// The elements of the tuple.
        /// </summary>
        public readonly IExprExt[] Operations;

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleExt"/> class.
        /// </summary>
        /// <param name="operations">The operations of this sequence.</param>
        public SeqExt(params IExprExt[] operations)
        {
            Operations = operations;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public ExprC Desugar()
        {
            SeqC result = new SeqC(
                Operations[Operations.Length - 2].Desugar(),
                Operations[Operations.Length - 1].Desugar()
            );
            for (int i = Operations.Length - 3; i >= 0; --i)
            {
                result = new SeqC(Operations[i].Desugar(), result);
            }
            return result;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SeqExt({string.Join(", ", Operations.AsEnumerable())})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SeqExt that)
            {
                return Operations.SequenceEqual(that.Operations);
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
            int result = GetType().GetHashCode();

            for (int i = 0; i < Operations.Length; ++i)
            {
                result *= Operations[i].GetHashCode() ^ (i + 1);
            }

            return result;
        }
    }
}
