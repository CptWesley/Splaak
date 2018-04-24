using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.Misc;

namespace Splaak.Core.AbstractSyntax.Misc
{
    /// <summary>
    /// Represents a mutation.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class SetExt : IExprExt
    {
        /// <summary>
        /// The name of the variable to set.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The argument for the mutation.
        /// </summary>
        public readonly IExprExt Argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetExt"/> class.
        /// </summary>
        /// <param name="name">The name of the variable to mutate.</param>
        /// <param name="arg">The value to set the variable to.</param>
        public SetExt(string name, IExprExt arg)
        {
            Name = name;
            Argument = arg;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public ExprC Desugar()
        {
            return new SetC(Name, Argument.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SetExt({Name}, {Argument})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SetExt that)
            {
                return that.Name.Equals(Name) && that.Argument.Equals(Argument);
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
            return GetType().GetHashCode() * Name.GetHashCode() * Argument.GetHashCode();
        }
    }
}
