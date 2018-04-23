using System.Collections.Generic;
using System.Linq;

namespace Splaak.Core.Values.Misc
{
    /// <summary>
    /// Represents an environment.
    /// </summary>
    public class Environment
    {
        private readonly Dictionary<string, Bind> _map;

        /// <summary>
        /// Initializes a new instance of the <see cref="Environment"/> class.
        /// </summary>
        public Environment()
        {
            _map = new Dictionary<string, Bind>();
        }

        /// <summary>
        /// Clones a <see cref="Environment"/> environment.
        /// </summary>
        /// <param name="map">The map.</param>
        private Environment(Dictionary<string, Bind> map)
        {
            _map = new Dictionary<string, Bind>(map);
        }

        /// <summary>
        /// Adds a bind to the environment..
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>A new copy of the environment</returns>
        public Environment Add(string key, Value value)
        {
            Environment copy = new Environment(_map);
            copy._map[key] = new Bind(value);
            return copy;
        }

        /// <summary>
        /// Updates the specified bind.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="InterpretException">Thrown when key does not exist in the environment.</exception>
        public void Update(string key, Value value)
        {
            if (!_map.ContainsKey(key)) throw new InterpretException($"Free variable '{key}' found.");
            _map[key].Value = value;
        }

        /// <summary>
        /// Retrieves the value of the bind at the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <exception cref="InterpretException">Thrown when key does not exist in the environment.</exception>
        public Value Lookup(string key)
        {
            if (!_map.ContainsKey(key)) throw new InterpretException($"Free variable '{key}' found.");
            return _map[key].Value;
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Environment({string.Join(", ", _map.Select(x => $"({x.Key}, {x.Value})").ToArray())})";

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Environment that)
            {
                return _map.Count == that._map.Count && !_map.Except(that._map).Any();
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
            int result = GetType().GetHashCode();
            foreach (KeyValuePair<string, Bind> binds in _map)
            {
                result *= binds.Key.GetHashCode() + binds.Value.GetHashCode();
            }
            return result;
        }
    }
}
