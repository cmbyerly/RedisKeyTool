namespace RedisKeyTool.Shared
{
    /// <summary>
    /// This is the key payload for adding, deleting and updating keys
    /// </summary>
    public class KeyPayload
    {
        /// <summary>
        /// Gets or sets the redis setting.
        /// </summary>
        /// <value>
        /// The redis setting.
        /// </value>
        public RedisSetting RedisSetting { get; set; }

        /// <summary>
        /// Gets or sets the key list item.
        /// </summary>
        /// <value>
        /// The key list item.
        /// </value>
        public KeyListItem KeyListItem { get; set; }
    }
}