using StackExchange.Redis;
using System;
using System.Collections.Generic;

namespace RedisKeyTool.Shared
{
    /// <summary>
    /// Key List Item
    /// </summary>
    public class KeyListItem
    {
        /// <summary>
        /// This is the redis type for the keys.
        /// </summary>
        /// <value>redis type for the key</value>
        private RedisType _keyRedisType;

        /// <summary>
        /// The key name.
        /// </summary>
        /// <value>
        /// The name
        /// </value>
        public string KeyName { get; set; }

        /// <summary>
        /// This is the key value.
        /// </summary>
        /// <value>
        /// the key value.
        /// </value>
        public List<KeyValue> KeyValues { get; set; }

        /// <summary>
        /// Whether or not it is a numeric value.
        /// </summary>
        /// <value>
        /// Whether or not it is a numeric value.
        /// </value>
        public bool IsNumeric { get; set; }

        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>
        /// The expiry.
        /// </value>
        public String Expiry { get; set; }

        /// <summary>
        /// Gets the type of the key.
        /// </summary>
        /// <value>
        /// The type of the key.
        /// </value>
        public string KeyType
        {
            get
            {
                var retval = _keyRedisType switch
                {
                    RedisType.String => "string",
                    RedisType.Hash => "hash",
                    RedisType.List => "list",
                    RedisType.None => "none",
                    RedisType.Set => "set",
                    RedisType.SortedSet => "sorted",
                    RedisType.Stream => "stream",
                    RedisType.Unknown => "unknown",
                    _ => "none",
                };
                return retval;
            }
            set
            {
                _keyRedisType = value switch
                {
                    "string" => RedisType.String,
                    "hash" => RedisType.Hash,
                    "list" => RedisType.List,
                    "none" => RedisType.None,
                    "set" => RedisType.Set,
                    "sorted" => RedisType.SortedSet,
                    "stream" => RedisType.Stream,
                    "unknown" => RedisType.Unknown,
                    _ => RedisType.None,
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyListItem"/> class.
        /// </summary>
        public KeyListItem()
        {
            this.KeyValues = new List<KeyValue>();
        }

        /// <summary>
        /// The constructor for the key list item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="keyRedisType">Type of the key redis.</param>
        public KeyListItem(string key, RedisType keyRedisType)
        {
            this.KeyValues = new List<KeyValue>();
            this.KeyName = key;
            this._keyRedisType = keyRedisType;
        }

        /// <summary>
        /// The constructor for the key list item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="isNumeric">if set to <c>true</c> [is numeric].</param>
        public KeyListItem(string key, List<KeyValue> value, bool isNumeric)
        {
            this.KeyName = key;
            this.KeyValues = value;
            this.IsNumeric = isNumeric;
            this._keyRedisType = RedisType.String;
        }

        /// <summary>
        /// The constructor for the key list item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="isNumeric">if set to <c>true</c> [is numeric].</param>
        /// <param name="keyRedisType">Type of the key redis.</param>
        public KeyListItem(string key, List<KeyValue> value, bool isNumeric, RedisType keyRedisType, TimeSpan? expiry)
        {
            this.KeyName = key;
            this.KeyValues = value;
            this._keyRedisType = keyRedisType;
            this.IsNumeric = isNumeric;

            if (expiry == null)
            {
                this.Expiry = "00:00:00";
            }
            else
            {
                this.Expiry = $"{expiry.Value.Hours.ToString().PadLeft(2, '0')}:{expiry.Value.Minutes.ToString().PadLeft(2, '0')}:{expiry.Value.Seconds.ToString().PadLeft(2, '0')}";
            }
        }
    }
}