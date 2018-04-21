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
        public SList(ISExpression[] expressions)
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
            if (Expressions.Length == 1 && Expressions[0] is SSym)
            {
                switch (((SSym) Expressions[0]).Value)
                {
                    case "not":
                        return new NotExt(Expressions[1].Parse());
                }
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
    }
}
