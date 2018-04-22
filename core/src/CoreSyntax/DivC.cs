using Splaak.Core.Values;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Represents a division in core syntax.
    /// </summary>
    /// <seealso cref="Splaak.Core.AbstractSyntax.IExprExt" />
    public class DivC : IExprC
    {
        /// <summary>
        /// The argument of the expression.
        /// </summary>
        public readonly IExprC Argument1, Argument2;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivC"/> class.
        /// </summary>
        /// <param name="arg1">The left argument of this expression.</param>
        /// <param name="arg2">The right argument of this expression.</param>
        public DivC(IExprC arg1, IExprC arg2)
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

            if (v1 is IntV && v2 is IntV) return new IntV(((IntV)v1).Value / ((IntV)v2).Value);
            if (v1 is FloatV && v2 is IntV) return new FloatV(((FloatV)v1).Value / ((IntV)v2).Value);
            if (v1 is IntV && v2 is FloatV) return new FloatV(((IntV)v1).Value / ((FloatV)v2).Value);
            if (v1 is FloatV && v2 is FloatV) return new FloatV(((FloatV)v1).Value / ((FloatV)v2).Value);

            throw new InterpretException();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"DivC({Argument1}, {Argument2})";

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is DivC)
            {
                DivC that = (DivC) obj;
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
