using Splaak.Core.Values;
using Splaak.Core.Values.Misc;
using Splaak.Core.Values.Types;

namespace Splaak.Core.CoreSyntax.BinOps
{
    /// <summary>
    /// Represents a multiplication in core syntax.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class MultC : ExprC
    {
        /// <summary>
        /// The argument of the expression.
        /// </summary>
        public readonly ExprC Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultC"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of this expression.</param>
        /// <param name="arg2">The right argument of this expression.</param>
        public MultC(ExprC arg1, ExprC arg2)
        {
            Argument1 = arg1;
            Argument2 = arg2;
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
            IValue v1 = Argument1.Interpret(env);
            IValue v2 = Argument2.Interpret(env);

            if (v1 is IntV   ii1 && v2 is IntV   ii2) return new IntV  (ii1.Value * ii2.Value);
            if (v1 is FloatV fi1 && v2 is IntV   fi2) return new FloatV(fi1.Value * fi2.Value);
            if (v1 is IntV   if1 && v2 is FloatV if2) return new FloatV(if1.Value * if2.Value);
            if (v1 is FloatV ff1 && v2 is FloatV ff2) return new FloatV(ff1.Value * ff2.Value);

            throw new InterpretException();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"MultC({Argument1}, {Argument2})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is MultC that)
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
