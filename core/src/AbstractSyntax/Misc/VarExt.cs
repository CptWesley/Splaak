using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.Misc;

namespace Splaak.Core.AbstractSyntax.Misc
{
    /// <summary>
    /// Represents a variable in abstract syntax.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class VarExt : IExprExt
    {
        /// <summary>
        /// The variable name of this abstract expression.
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VarExt"/> class.
        /// </summary>
        /// <param name="value">The variable name of this abstract expression.</param>
        public VarExt(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public ExprC Desugar()
        {
            return new VarC(Value);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"VarExt({Value})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is VarExt that)
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
