using System;
using System.Collections.Generic;
using System.Text;

namespace Splaak.Core.Reader
{
    /// <summary>
    /// A string reading class that exposes more state.
    /// </summary>
    internal class StringReader
    {
        #region Constants

        private const string StringEndMessage = "The string cannot be read further. Use the " + nameof(CanRead) + " property to check if the string can be read.";
        private const char NewlineCharacter = (char)10;
        #endregion

        #region Fields

        private string _s;
        private int _index;

        private int _line = 1;
        private int _column = 1;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReader" /> class.
        /// </summary>
        /// <param name="s">The string to read.</param>
        public StringReader(string s)
        {
            _s = s ?? throw new ArgumentNullException(nameof(s));
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets whether the string can be read further.
        /// </summary>
        public bool CanRead => _index < _s.Length;

        /// <summary>
        /// Gets the current zero-based position in the string.
        /// </summary>
        public int Index => _index;

        /// <summary>
        /// Gets the line (vertical) position in the string.
        /// </summary>
        public int Line => _line;

        /// <summary>
        /// Gets the column (horizontal) position in the string.
        /// </summary>
        public int Column => _column;
        #endregion

        #region Methods

        /// <summary>
        /// Peeks at the value of the next character without advancing the reader's position.
        /// </summary>
        /// <returns>The value of the next character.</returns>
        public char Peek()
        {
            return CanRead ? _s[_index] : throw new InvalidOperationException(StringEndMessage);
        }

        /// <summary>
        /// Gets the value of the next character and advances the reader's position.
        /// </summary>
        /// <returns>The value of the next character.</returns>
        public char Read()
        {
            char c = Peek();
            AdvancePosition(c);
            return c;
        }

        /// <summary>
        /// Reads while the given predicate is true.
        /// </summary>
        /// <param name="predicate">The predicate which must be true to continue reading.</param>
        /// <returns>A string containing the read value.</returns>
        public string ReadWhile(Func<char, bool> predicate)
        {
            // Local function to allow for easy IEnumerable creation
            IEnumerable<char> PredicateEnumerable()
            {
                while (CanRead && predicate(_s[_index]))
                {
                    yield return Read();
                }
            }

            // string.Concat uses a StringBuilder internally
            return string.Concat(PredicateEnumerable());
        }

        /// <summary>
        /// Advances the reader's position.
        /// </summary>
        /// <param name="c">The current character.</param>
        private void AdvancePosition(char c)
        {
            ++_index;
            bool isNewline = c == NewlineCharacter;
            if (isNewline)
            {
                ++_line;
                _column = 1;
            }
            else
            {
                ++_column;
            }
        }

        #region Overriding

        public override string ToString()
        {
            return $"{nameof(StringReader)}({nameof(Index)}: {Index}, {nameof(Line)}: {Line}, {nameof(Column)}: {Column})";
        }
        #endregion
        #endregion
    }
}
