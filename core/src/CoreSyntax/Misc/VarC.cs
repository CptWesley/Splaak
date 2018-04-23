using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax.Misc
{
    /// <summary>
    /// Represents a variable in core syntax.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class VarC : ExprC
    {
        /// <summary>
        /// The variable name of this core expression.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VarC"/> class.
        /// </summary>
        /// <param name="value">The variable name of this core expression.</param>
        public VarC(string value)
        {
            Value = value;
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
            return env.Lookup(Value);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"VarC({Value})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is VarC that)
            {
                return that.Value == Value;
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
            return GetType().GetHashCode() * Value.GetHashCode();
        }
    }
}
