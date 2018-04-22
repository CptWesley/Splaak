using System.Collections.Generic;
using System.Text;
using Splaak.Core.AbstractSyntax;

namespace Splaak.Core.Reader.Expressions
{
    /// <summary>
    /// Represents a list of S-expressions.
    /// </summary>
    /// <seealso cref="Splaak.Core.Reader.Expressions.ISExpression" />
    public class SList : ISExpression
    {
        /// <summary>
        /// The s-expressions contained in this list.
        /// </summary>
        public readonly ISExpression[] Expressions;

        /// <summary>
        /// Initializes a new instance of the <see cref="SList"/> class.
        /// </summary>
        /// <param name="expressions">The expressions contained in this list.</param>
        public SList(params ISExpression[] expressions)
        {
            Expressions = expressions;
        }

        /// <summary>
        /// Parses this s-expression.
        /// </summary>
        /// <returns>
        /// Abstract syntax-tree structure.
        /// </returns>
        public IExprExt Parse()
        {
            SSym s;
            if (Expressions.Length == 2 && Expressions[0] is SSym)
            {
                switch (((SSym) Expressions[0]).Value)
                {
                    case "not":
                        return new NotExt(Expressions[1].Parse());
                    case "-":
                        return new UnMinExt(Expressions[1].Parse());
                    case "first":
                        return new FirstExt(Expressions[1].Parse());
                    case "second":
                        return new SecondExt(Expressions[1].Parse());
                }
            }
            else if (Expressions.Length == 3 && Expressions[0] is SSym)
            {
                switch (((SSym)Expressions[0]).Value)
                {
                    case "+":
                        return new PlusExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "-":
                        return new BinMinExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "*":
                        return new MultExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "/":
                        return new DivExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "and":
                        return new AndExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "or":
                        return new OrExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "=":
                        return new EqExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "<":
                        return new LtExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "<=":
                        return new LeqExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case ">":
                        return new GtExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case ">=":
                        return new GeqExt(Expressions[1].Parse(), Expressions[2].Parse());
                    case "pair":
                        return new PairExt(Expressions[1].Parse(), Expressions[2].Parse());
                }
            }
            else if (Expressions.Length == 4 && (s = (SSym) Expressions[0]) != null && s.Value == "if")
            {
                return new IfExt(Expressions[1].Parse(), Expressions[2].Parse(), Expressions[3].Parse());
            }
            else if (Expressions.Length >= 3 && (s = (SSym) Expressions[0]) != null && s.Value == "tuple")
            {
                List<IExprExt> elements = new List<IExprExt>();
                for (int i = 1; i < Expressions.Length; ++i)
                {
                    elements.Add(Expressions[i].Parse());
                }
                return new TupleExt(elements.ToArray());
            }
            throw new ParseException();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SList(");
            for (int i = 0; i < Expressions.Length; ++i)
            {
                sb.Append(Expressions[i]);
                if (i != Expressions.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SList)
            {
                SList that = (SList) obj;
                if (that.Expressions.Length != Expressions.Length)
                {
                    return false;
                }
                for (int i = 0; i < Expressions.Length; ++i)
                {
                    ISExpression here = Expressions[i];
                    ISExpression there = that.Expressions[i];
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

            for (int i = 0; i < Expressions.Length; ++i)
            {
                result *= Expressions[i].GetHashCode() ^ (i + 1);
            }

            return result;
        }
    }
}
