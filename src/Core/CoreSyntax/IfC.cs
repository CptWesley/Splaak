using System;
using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents an if-statement in the core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.CoreSyntax.IExprC" />
    public class IfC : IExprC
    {
        /// <summary>
        /// The arguments of the if-statement.
        /// </summary>
        public readonly IExprC Condition, Then, Else;

        /// <summary>
        /// Initializes a new instance of the <see cref="IfC"/> class.
        /// </summary>
        /// <param name="condition">The condition of the if-statement.</param>
        /// <param name="then">The path taken when the condition is true.</param>
        /// <param name="els">The path taken when the condition is false.</param>
        public IfC(IExprC condition, IExprC then, IExprC els)
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
        /// <exception cref="NotImplementedException"></exception>
        public IValue Interpret()
        {
            IValue condv = Condition.Interpret();
            if (!(condv is BoolV)) throw new InterpretException();
            if (((BoolV) condv).Value)
            {
                return Then.Interpret();
            }
            return Else.Interpret();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("IfC({0}, {1}, {2})",
            Condition, Then, Else);
    }
}
