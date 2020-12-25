using StackExchange.Redis;

namespace RedisKeyTool.Shared
{
    /// <summary>
    /// This is for our Redis Key Types
    /// </summary>
    public class KeyType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyType"/> class.
        /// </summary>
        public KeyType() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyType"/> class.
        /// </summary>
        /// <param name="keyTypeName">Name of the key type.</param>
        /// <param name="redisType">Type of the redis.</param>
        public KeyType(string keyTypeName, RedisType redisType)
        {
            KeyTypeName = keyTypeName;
            RedisType = redisType;
        }

        /// <summary>
        /// Gets or sets the name of the key type.
        /// </summary>
        /// <value>
        /// The name of the key type.
        /// </value>
        public string KeyTypeName { get; set; }

        /// <summary>
        /// Gets or sets the type of the redis.
        /// </summary>
        /// <value>
        /// The type of the redis.
        /// </value>
        public RedisType RedisType { get; set; }
    }
}