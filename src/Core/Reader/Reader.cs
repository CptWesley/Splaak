using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Splaak.Core.Reader.Expressions;

namespace Splaak.Core.Reader
{
    //TODO: FIX THIS MESS.

    /// <summary>
    /// Class used for reading Splaak code.
    /// </summary>
    public static class Reader
    {
        /// <summary>
        /// Reads the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>S-expression presented in the input.</returns>
        public static ISExpression Read(this string input)
        {
            using (StringReader sr = new StringReader(input))
            {
                return Read(sr);
            }
        }

        private static ISExpression Read(StringReader reader)
        {
            while (true)
            {
                char c = (char) reader.Peek();
                if (c == '(')
                {
                    reader.Read();
                    return ReadList(reader);
                }
                else if (c == ')')
                {
                    throw new ReaderException();
                }
                else if (c >= 33 && c <= 126)
                {
                    return ReadWord(reader);
                }
                else
                {
                    reader.Read();
                }
            }
        }

        private static ISExpression ReadList(StringReader reader)
        {
            List<ISExpression> expressions = new List<ISExpression>();

            while (true)
            {
                char c = (char) reader.Peek();
                if (c == ')')
                {
                    reader.Read();
                    return new SList(expressions.ToArray());
                }
                else if (c >= 33 && c <= 126)
                {
                    expressions.Add(Read(reader));
                }
                else
                {
                    reader.Read();
                }
            }
        }

        private static ISExpression ReadWord(StringReader reader)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                char c = (char) reader.Peek();
                if (c >= 33 && c <= 126 && c != '(' && c != ')')
                {
                    reader.Read();
                    sb.Append(c);
                }
                else
                {
                    string value = sb.ToString();
                    try
                    {
                        return new SInt(int.Parse(value, CultureInfo.InvariantCulture));
                    }
                    catch (FormatException)
                    {
                        try
                        {
                            return new SFloat(float.Parse(value, CultureInfo.InvariantCulture));
                        }
                        catch (FormatException)
                        {
                            return new SSym(value);
                        }
                    }
                }
            }
        }
    }
}
