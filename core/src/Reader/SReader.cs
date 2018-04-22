using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Splaak.Core.Reader.Expressions;
using Splaak.Core.Values;

namespace Splaak.Core.Reader
{
    //TODO: FIX THIS MESS.

    /// <summary>
    /// Class used for reading Splaak code.
    /// </summary>
    public static class SReader
    {
        private const char ListStart = '(';
        private const char ListEnd = ')';
        private const char ListSeparator = ' ';

        private static readonly Func<char, bool> CharacterSkipPredicate = (char c) => char.IsWhiteSpace(c) ||
                                                                                      char.IsControl(c);

        private static readonly Func<char, bool> SameWordPredicate = (char c) => c != ListEnd &&
                                                                                 !CharacterSkipPredicate(c);

        /// <summary>
        /// Reads the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>S-expression presented in the input.</returns>
        public static ISExpression Read(this string input)
        {
            return ReadRoot(new StringReader(input));
        }

        /// <summary>
        /// Executes the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The value obtained by executing the output.</returns>
        public static IValue Execute(this string input)
        {
            return input.Read().Parse().Desugar().Interpret();
        }

        private static void Skip(this StringReader reader)
        {
            reader.ReadWhile(CharacterSkipPredicate);
        }

        private static ISExpression ReadRoot(StringReader reader)
        {
            ISExpression expression = Read(reader);
            reader.Skip();

            if (reader.CanRead)
            {
                throw new ReaderException($"End of structure was expected, found '{reader.Peek()}' instead.");
            }

            return expression;
        }

        private static ISExpression Read(StringReader reader)
        {
            reader.Skip();
            char c = reader.Peek();

            if (c == ListStart)
            {
                return ReadList(reader);
            }
            else if (c == ListEnd)
            {
                throw new ReaderException($"Parenthesis mismatch: closing parenthesis was not opened at line {reader.Line}, column {reader.Column}.");
            }
            else
            {
                return ReadWord(reader);
            }
        }

        private static ISExpression ReadList(StringReader reader)
        {
            List<ISExpression> expressions = new List<ISExpression>();

            int ln = reader.Line, col = reader.Column;

            reader.Read(); // pop off opening parenthesis

            while (reader.CanRead)
            {
                reader.Skip();
                char c = reader.Peek();
                if (c == ListEnd)
                {
                    reader.Read(); // pop off closing parenthesis
                    return new SList(expressions.ToArray());
                }
                else
                {
                    expressions.Add(Read(reader));
                }
            }

            throw new ReaderException($"Parenthesis mismatch: opening parenthesis was not closed at line {ln}, column {col}. End of structure expected.");
        }

        private static ISExpression ReadWord(StringReader reader)
        {
            reader.Skip();
            string word = reader.ReadWhile(SameWordPredicate);
            if (int.TryParse(word, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out int integerValue))
            {
                return new SInt(integerValue);
            }
            else if (float.TryParse(word, NumberStyles.Float, CultureInfo.InvariantCulture.NumberFormat, out float floatValue))
            {
                return new SFloat(floatValue);
            }
            else
            {
                return new SSym(word);
            }
        }
    }
}
