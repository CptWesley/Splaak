using System.Collections.Generic;

namespace Splaak.Core.Values
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
        public Environment Add(string key, IValue value)
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
        public void Update(string key, IValue value)
        {
            if (!_map.ContainsKey(key)) throw new InterpretException($"Free variable '{key}' found.");
            _map[key].Value = value;
        }

        /// <summary>
        /// Retrieves the value of the bind at the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <exception cref="InterpretException">Thrown when key does not exist in the environment.</exception>
        public IValue Lookup(string key)
        {
            if (!_map.ContainsKey(key)) throw new InterpretException($"Free variable '{key}' found.");
            return _map[key].Value;
        }
    }
}
