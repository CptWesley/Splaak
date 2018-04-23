namespace Splaak.Core.Values
{
    /// <summary>
    /// Represents an environment bind.
    /// </summary>
    public class Bind
    {

        /// <summary>
        /// The value of this bind.
        /// </summary>
        public IValue Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bind"/> class.
        /// </summary>
        /// <param name="value">The value of the bind.</param>
        public Bind(IValue value)
        {
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Bind({Value})";
    }
}
