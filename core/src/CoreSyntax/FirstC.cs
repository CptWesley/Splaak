using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents a getter for the first element of a pair.
    /// </summary>
    /// <seealso cref="IExprC" />
    public class FirstC : IExprC
    {
        /// <summary>
        /// The pair to extract the first element from.
        /// </summary>
        public readonly IExprC Argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="FirstC"/> class.
        /// </summary>
        /// <param name="arg">The pair to extract the first element from.</param>
        public FirstC(IExprC arg)
        {
            Argument = arg;
        }

        /// <summary>
        /// Interprets this core expression.
        /// </summary>
        /// <returns>
        /// Resulting value.
        /// </returns>
        public IValue Interpret()
        {
            IValue v = Argument.Interpret();
            if (v is PairV pair)
            {
                return pair.Left;
            }
            throw new InterpretException();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"FirstC({Argument})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is FirstC that)
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
