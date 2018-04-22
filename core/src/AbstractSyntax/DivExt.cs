using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a division.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class DivExt : IExprExt
    {
        /// <summary>
        /// The arguments for the division.
        /// </summary>
        public readonly IExprExt Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivExt"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of the division.</param>
        /// <param name="arg2">The right argument of the division.</param>
        public DivExt(IExprExt arg1, IExprExt arg2)
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
            return new DivC(Argument1.Desugar(), Argument2.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("DivExt({0}, {1})", Argument1.ToString(), Argument2.ToString());

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is DivExt)
            {
                DivExt that = (DivExt) obj;
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
