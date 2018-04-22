using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.BinOps;
using Splaak.Core.CoreSyntax.Misc;
using Splaak.Core.CoreSyntax.Types;

namespace Splaak.Core.AbstractSyntax.BinOps
{
    /// <summary>
    /// Represents a lesser-than-or-equals.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class LeqExt : IExprExt
    {
        /// <summary>
        /// The arguments for the lesser-than-or-equal.
        /// </summary>
        public readonly IExprExt Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeqExt"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of the lesser-than-or-equals.</param>
        /// <param name="arg2">The right argument of the lesser-than-or-equals.</param>
        public LeqExt(IExprExt arg1, IExprExt arg2)
        {
            Argument1 = arg1;
            Argument2 = arg2;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            IExprC arg1 = Argument1.Desugar();
            IExprC arg2 = Argument2.Desugar();
            return new IfC(new LtC(arg1, arg2), new BoolC(true), new EqC(arg1, arg2));
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"LeqExt({Argument1}, {Argument2})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is LeqExt that)
            {
                return that.Argument1.Equals(Argument1) && that.Argument2.Equals(Argument2);
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
            return GetType().GetHashCode() * Argument1.GetHashCode() * Argument2.GetHashCode() ^ 2;
        }
    }
}
