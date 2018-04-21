namespace Splaak.Core.Values
{
    /// <summary>
    /// Represents an integer.
    /// </summary>
    /// <seealso cref="Splaak.Core.Values.IValue" />
    public class IntV : IValue
    {
        /// <summary>
        /// The integer value.
        /// </summary>
        public readonly int Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntV"/> class.
        /// </summary>
        /// <param name="value">The integer value.</param>
        public IntV(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("IntV({0})", Value);
    }
}
