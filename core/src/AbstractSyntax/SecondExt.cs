using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a getter for the right element of a pair.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class SecondExt : IExprExt
    {
        /// <summary>
        /// The argument of the not expression.
        /// </summary>
        public readonly IExprExt Argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondExt"/> class.
        /// </summary>
        /// <param name="argument">The argument of the second expression.</param>
        public SecondExt(IExprExt argument)
        {
            Argument = argument;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            return new SecondC(Argument.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SecondExt({Argument})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SecondExt that)
            {
                return that.Argument.Equals(Argument);
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
            return GetType().GetHashCode() * Argument.GetHashCode();
        }
    }
}
