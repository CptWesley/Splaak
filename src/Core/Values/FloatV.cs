namespace Splaak.Core.Values
{
    /// <summary>
    /// Represents a float.
    /// </summary>
    /// <seealso cref="Splaak.Core.Values.IValue" />
    public class FloatV : IValue
    {
        /// <summary>
        /// The float value.
        /// </summary>
        public readonly float Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="FloatV"/> class.
        /// </summary>
        /// <param name="value">The float value.</param>
        public FloatV(float value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => string.Format("FloatV({0})", Value);
    }
}
