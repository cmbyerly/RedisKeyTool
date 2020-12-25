using System;

namespace RedisKeyTool.Shared
{
    /// <summary>
    /// This is our redis setting for the connected server.
    /// </summary>
    [Serializable]
    public class RedisSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedisSetting"/> class.
        /// </summary>
        public RedisSetting()
        {
            this.SettingName = string.Empty;
            this.RedisUrl = "localhost:6379";
            this.RedisUsername = string.Empty;
            this.RedisPassword = string.Empty;
            this.SelectedDatabase = 0;
            this.AllowAdmin = true;
            this.KeyPage = 0;
        }

        /// <summary>
        /// Gets or sets the name of the setting.
        /// </summary>
        /// <value>
        /// The name of the setting.
        /// </value>
        public string SettingName { get; set; }

        /// <summary>
        /// Gets the redis URL.
        /// </summary>
        /// <value>
        /// The redis URL.
        /// </value>
        public string RedisUrl { get; set; }

        /// <summary>
        /// Gets or sets the redis username.
        /// </summary>
        /// <value>
        /// The redis username.
        /// </value>
        public string RedisUsername { get; set; }

        /// <summary>
        /// Gets or sets the redis password.
        /// </summary>
        /// <value>
        /// The redis password.
        /// </value>
        public string RedisPassword { get; set; }

        /// <summary>
        /// Gets or sets the selected database.
        /// </summary>
        /// <value>
        /// The selected database.
        /// </value>
        public int SelectedDatabase { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow admin].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow admin]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowAdmin { get; set; }

        /// <summary>
        /// Gets or sets the key page.
        /// </summary>
        /// <value>
        /// The key page.
        /// </value>
        public int KeyPage { get; set; }
    }
}