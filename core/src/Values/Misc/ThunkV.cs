﻿using Splaak.Core.CoreSyntax;

namespace Splaak.Core.Values.Misc
{
    /// <summary>
    /// Represents a thunk (used for delayed execution).
    /// </summary>
    public class ThunkV : Value
    {
        /// <summary>
        /// The value of this thunk.
        /// </summary>
        public Value Value { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is interpreted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is interpreted; otherwise, <c>false</c>.
        /// </value>
        public bool IsInterpreted => Value != null;

        /// <summary>
        /// The expression of the thunk.
        /// </summary>
        public ExprC Expression { get; private set; }

        /// <summary>
        /// The environment of the thunk.
        /// </summary>
        public Environment Environment { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThunkV"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="environment">The environment.</param>
        public ThunkV(ExprC expression, Environment environment)
        {
            Expression = expression;
            Environment = environment;
            Value = null;
        }

        /// <summary>
        /// Forces this value to compute if it's a thunk.
        /// </summary>
        /// <returns>
        /// The computed variant of this value.
        /// </returns>
        public override Value Strict()
        {
            if (!IsInterpreted)
            {
                Value = Expression.Interpret(Environment);
                Expression = null;
                Environment = null;
            }
            return Value;
        }

        /// <summary>
        /// Forces this value to compute all thunks recursively.
        /// </summary>
        /// <returns>
        /// The fully computed variant of this value.
        /// </returns>
        public override Value Force()
        {
            if (!IsInterpreted)
            {
                Value = Expression.Interpret(Environment).Force();
                Expression = null;
                Environment = null;
            }
            return Value.Force();
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (IsInterpreted)
            {
                return $"ThunkV({Value})";
            }
            return $"ThunkV({Expression}, {Environment})";
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
            if (obj is ThunkV that)
            {
                if (IsInterpreted && that.IsInterpreted)
                {
                    return Value.Equals(that.Value);
                }
                if (!IsInterpreted && !that.IsInterpreted)
                {
                    return Expression.Equals(that.Expression) && Environment.Equals(that.Environment);
                }
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
            if (IsInterpreted)
            {
                return GetType().GetHashCode() * Value.GetHashCode();
            }
            return GetType().GetHashCode() * Expression.GetHashCode() * Environment.GetHashCode();
        }
    }
}
