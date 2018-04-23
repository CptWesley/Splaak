using Splaak.Core.Values;
using Splaak.Core.Values.Misc;

namespace Splaak.Core.CoreSyntax
{
    /// <summary>
    /// Abstract class for the core syntax.
    /// </summary>
    public abstract class ExprC
    {
        /// <summary>
        /// Interprets this core expression with an environment.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <returns>Resulting value.</returns>
        public abstract IValue Interpret(Environment env);

        /// <summary>
        /// Interprets this core expression.
        /// </summary>
        /// <returns>Resulting value.</returns>
        /// <exception cref="InterpretException"></exception>
        public IValue Interpret()
        {
            return Interpret(new Environment());
        }
    }
}
