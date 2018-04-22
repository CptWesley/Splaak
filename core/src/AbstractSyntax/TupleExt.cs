﻿using System.Text;
using Splaak.Core.CoreSyntax;

namespace Splaak.Core.AbstractSyntax
{
    /// <summary>
    /// Represents a tuple.
    /// </summary>
    /// <seealso cref="IExprExt" />
    public class TupleExt : IExprExt
    {
        /// <summary>
        /// The elements of the tuple.
        /// </summary>
        public readonly IExprExt[] Elements;

        /// <summary>
        /// Initializes a new instance of the <see cref="TupleExt"/> class.
        /// </summary>
        /// <param name="elements">The elements of this tuple.</param>
        public TupleExt(IExprExt[] elements)
        {
            Elements = elements;
        }

        /// <summary>
        /// Desugars this abstract expression.
        /// </summary>
        /// <returns>
        /// Core expression variant.
        /// </returns>
        public IExprC Desugar()
        {
            PairC result = new PairC(
                    Elements[Elements.Length - 2].Desugar(),
                    Elements[Elements.Length - 1].Desugar()
                );
            for (int i = Elements.Length - 3; i >= 0; --i)
            {
                result = new PairC(Elements[i].Desugar(), result);
            }
            return result;
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
            sb.Append("TupleExt(");
            for (int i = 0; i < Elements.Length; ++i)
            {
                sb.Append(Elements[i]);
                if (i != Elements.Length - 1)
                {
                    sb.Append(", ");
                }
            }
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
            if (obj is TupleExt)
            {
                TupleExt that = (TupleExt) obj;
                if (that.Elements.Length != Elements.Length)
                {
                    return false;
                }
                for (int i = 0; i < Elements.Length; ++i)
                {
                    IExprExt here = Elements[i];
                    IExprExt there = that.Elements[i];
                    if (here == null && there == null) continue;
                    if (here == null || !here.Equals(there))
                    {
                        return false;
                    }
                }
                return true;
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
            int result = GetType().GetHashCode();

            for (int i = 0; i < Elements.Length; ++i)
            {
                result *= Elements[i].GetHashCode() ^ (i + 1);
            }

            return result;
        }
    }
}