﻿using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents a multiplication in core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class MultC : IExprC
    {
        /// <summary>
        /// The argument of the expression.
        /// </summary>
        public readonly IExprC Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultC"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of this expression.</param>
        /// <param name="arg2">The right argument of this expression.</param>
        public MultC(IExprC arg1, IExprC arg2)
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
        public IValue Interpret()
        {
            IValue v1 = Argument1.Interpret();
            IValue v2 = Argument2.Interpret();

            if (v1 is IntV && v2 is IntV) return new IntV(((IntV)v1).Value * ((IntV)v2).Value);
            if (v1 is FloatV && v2 is IntV) return new FloatV(((FloatV)v1).Value * ((IntV)v2).Value);
            if (v1 is IntV && v2 is FloatV) return new FloatV(((IntV)v1).Value * ((FloatV)v2).Value);
            if (v1 is FloatV && v2 is FloatV) return new FloatV(((FloatV)v1).Value * ((FloatV)v2).Value);

            throw new InterpretException();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("MultC({0}, {1})", Argument1, Argument2);
    }
}
