using Splaak.Core.Values;
using Splaak.Core.Values.Misc;

namespace Splaak.Core.CoreSyntax.Misc
{
    /// <summary>
    /// Represents a mutation in core syntax.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class SetC : ExprC
    {
        /// <summary>
        /// The name of the variable to set.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The argument of the mutation.
        /// </summary>
        public readonly ExprC Argument;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetC"/> class.
        /// </summary>
        /// <param name="name">The name of the variable to change.</param>
        /// <param name="arg">The argument to set the variable to.</param>
        public SetC(string name, ExprC arg)
        {
            Name = name;
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
        public override Value Interpret(Environment env)
        {
            env.Update(Name, Argument.Interpret(env));
            return env.Lookup(Name);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SetC({Name}, {Argument})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SetC that)
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
