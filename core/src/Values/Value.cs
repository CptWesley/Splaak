namespace Splaak.Core.Values
{
    /// <summary>
    /// Interface for interpreted values.
    /// </summary>
    public abstract class Value
    {
        /// <summary>
        /// Forces this value to compute if it's a thunk.
        /// </summary>
        /// <returns>The computed variant of this value.</returns>
        public virtual Value Strict()
        {
            return this;
        }

        /// <summary>
        /// Forces this value to compute all thunks recursively.
        /// </summary>
        /// <returns>The fully computed variant of this value.</returns>
        public virtual Value Force()
        {
            return this;
        }
    }
}
