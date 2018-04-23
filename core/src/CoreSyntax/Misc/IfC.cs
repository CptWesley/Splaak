using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax.Misc
{
    /// <summary>
    /// Represents an if-statement in the core syntax.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class IfC : ExprC
    {
        /// <summary>
        /// The arguments of the if-statement.
        /// </summary>
        public readonly ExprC Condition, Then, Else;

        /// <summary>
        /// Initializes a new instance of the <see cref="IfC"/> class.
        /// </summary>
        /// <param name="condition">The condition of the if-statement.</param>
        /// <param name="then">The path taken when the condition is true.</param>
        /// <param name="els">The path taken when the condition is false.</param>
        public IfC(ExprC condition, ExprC then, ExprC els)
        {
            Condition = condition;
            Then = then;
            Else = els;
        }

        /// <summary>
        /// Interprets this core expression.
        /// </summary>
        /// <returns>
        /// Resulting value.
        /// </returns>
        /// <exception cref="InterpretException"></exception>
        public override IValue Interpret(Environment env)
        {
            IValue condv = Condition.Interpret(env);
            if (condv is BoolV cond)
            {
                return cond.Value ? Then.Interpret() : Else.Interpret();
            }
            throw new InterpretException();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"IfC({Condition}, {Then}, {Else})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is IfC that)
            {
                return that.Condition.Equals(Condition) &&
                       that.Then.Equals(Then) &&
                       that.Else.Equals(Else);
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
            return GetType().GetHashCode() *
                   Condition.GetHashCode() *
                   Then.GetHashCode() ^ 2 *
                   Else.GetHashCode() ^ 3;
        }
    }
}
