using System.Linq;
using Splaak.Core.AbstractSyntax;

namespace Splaak.Core.Reader.Expressions
{
    /// <summary>
    /// Represents a list of S-expressions.
    /// </summary>
    /// <seealso cref="ISExpression" />
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
            if (Expressions[0] is SSym op)
            {
                if (Expressions.Length == 2)
                {
                    switch (op.Value)
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
                else if (Expressions.Length == 3)
                {
                    switch (op.Value)
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
                else if (Expressions.Length == 4 && op.Value == "if")
                {
                    return new IfExt(Expressions[1].Parse(), Expressions[2].Parse(), Expressions[3].Parse());
                }
                else if (Expressions.Length >= 3 && op.Value == "tuple")
                {
                    return new TupleExt(Expressions.Skip(1).Select(e => e.Parse()).ToArray());
                }
            }
            throw new ParseException();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string /> that represents this instance.
        /// </returns>
        public override string ToString() => $"SList({string.Join(", ", Expressions.AsEnumerable())})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is SList that)
            {
                return Expressions.SequenceEqual(that.Expressions);
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
