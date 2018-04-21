using System;
using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents an addition in core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class PlusC : IExprC
    {
        /// <summary>
        /// The argument of the expression.
        /// </summary>
        public readonly IExprC Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlusC"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of this expression.</param>
        /// <param name="arg2">The right argument of this expression.</param>
        public PlusC(IExprC arg1, IExprC arg2)
        {
            Argument1 = arg1;
            Argument2 = arg2;
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
            IValue v1, v2;
            if (!((v1 = Argument1.Interpret()) is IntV)) throw new InterpretException();
            if (!((v2 = Argument2.Interpret()) is IntV)) throw new InterpretException();
            return new IntV(((IntV) v1).Value + ((IntV) v2).Value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("PlusC({0}, {1})", Argument1, Argument2);
    }
}
