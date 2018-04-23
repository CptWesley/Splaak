using Splaak.Core.Values;
using Splaak.Core.Values.Misc;
using Splaak.Core.Values.Types;

namespace Splaak.Core.CoreSyntax.UnOps
{
    /// <summary>
    /// Represents a getter for the first element of a pair.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class SecondC : ExprC
    {
        /// <summary>
        /// The pair to extract the first element from.
        /// </summary>
        public readonly ExprC Argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondC"/> class.
        /// </summary>
        /// <param name="arg">The pair to extract the first element from.</param>
        public SecondC(ExprC arg)
        {
            Argument = arg;
        }

        /// <summary>
        /// Interprets this core expression with an environment.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <returns>
        /// Resulting value.
        /// </returns>
        /// <exception cref="InterpretException"></exception>
        public override IValue Interpret(Environment env)
        {
            IValue v = Argument.Interpret(env);
            if (v is PairV pair)
            {
                return pair.Right;
            }
            throw new InterpretException();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SecondC({Argument})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SecondC that)
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
