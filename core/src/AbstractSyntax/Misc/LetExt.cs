using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Splaak.Core.CoreSyntax;
using Splaak.Core.CoreSyntax.Misc;

namespace Splaak.Core.AbstractSyntax.Misc
{
    /// <summary>
    /// Represents a let-expression.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class LetExt : IExprExt
    {
        /// <summary>
        /// The binds of the let-expression.
        /// </summary>
        public readonly Tuple<string, IExprExt>[] Binds;

        /// <summary>
        /// The body of the let-expression.
        /// </summary>
        public readonly IExprExt Body;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetExt"/> class.
        /// </summary>
        /// <param name="binds">The binds of the let-expression.</param>
        /// <param name="body">The body of the let-expression.</param>
        public LetExt(Tuple<string, IExprExt>[] binds, IExprExt body)
        {
            Binds = binds;
            Body = body;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public ExprC Desugar()
        {
            Tuple<string, ExprC>[] desugaredBinds = new Tuple<string, ExprC>[Binds.Length];

            for (int i = 0; i < Binds.Length; ++i)
            {
                desugaredBinds[i] = new Tuple<string, ExprC>(Binds[i].Item1, Binds[i].Item2.Desugar());
            }

            return new LetC(desugaredBinds, Body.Desugar());
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("LetC((");

            for (int i = 0; i < Binds.Length; ++i)
            {
                sb.Append($"({Binds[i].Item1}, {Binds[i].Item2})");
                if (i != Binds.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append("), ");
            sb.Append(Body);
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is LetExt that)
            {
                return Binds.SequenceEqual(that.Binds) && that.Body.Equals(Body);
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
            int result = GetType().GetHashCode() * Body.GetHashCode();

            for (int i = 0; i < Binds.Length; ++i)
            {
                result *= Binds[i].GetHashCode() ^ (i + 1);
            }

            return result;
        }
    }
}
