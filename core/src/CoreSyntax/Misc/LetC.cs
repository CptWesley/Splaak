using System;
using System.Linq;
using System.Text;
using Splaak.Core.Values;
using Splaak.Core.Values.Types;
using Environment = Splaak.Core.Values.Misc.Environment;

namespace Splaak.Core.CoreSyntax.Misc
{
    /// <summary>
    /// Represents a let-expression in core syntax.
    /// </summary>
    /// <seealso cref="ExprC" />
    public class LetC : ExprC
    {
        /// <summary>
        /// The binds of the let-expression.
        /// </summary>
        public readonly Tuple<string, ExprC>[] Binds;

        /// <summary>
        /// The body of the let-expression.
        /// </summary>
        public readonly ExprC Body;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetC"/> class.
        /// </summary>
        /// <param name="binds">The binds of the let-expression.</param>
        /// <param name="body">The body of the let-expression.</param>
        public LetC(Tuple<string, ExprC>[] binds, ExprC body)
        {
            Binds = binds;
            Body = body;
        }

        /// <summary>
        /// Interprets this core expression with an environment.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <returns>
        /// Resulting value.
        /// </returns>
        /// <exception cref="InterpretException"></exception>
        public override IValue Interpret(Environment env)
        {
            foreach (Tuple<string, ExprC> bind in Binds)
                env = env.Add(bind.Item1, new NullV());
            foreach (Tuple<string, ExprC> bind in Binds)
            {
                // TODO: Thunks!
                env.Update(bind.Item1, bind.Item2.Interpret(env));
            }
            return Body.Interpret(env);
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
            if (obj is LetC that)
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
