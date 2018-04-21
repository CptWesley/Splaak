namespace Splaak.Core.Values
{
    /// <summary>
    /// Represents a boolean.
    /// </summary>
    /// <seealso cref="Splaak.Core.Values.IValue" />
    public class BoolV : IValue
    {
        /// <summary>
        /// The boolean value.
        /// </summary>
        public readonly bool Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntV"/> class.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        public BoolV(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("BoolV({0})", Value);
    }
}
