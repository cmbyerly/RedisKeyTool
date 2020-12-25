using System;

namespace RedisKeyTool.Shared
{
    /// <summary>
    /// This is our redis setting for the connected server.
    /// </summary>
    [Serializable]
    public class ConnectionKiller : RedisSetting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RedisSetting"/> class.
        /// </summary>
        public ConnectionKiller()
        {
            this.SettingName = string.Empty;
            this.RedisUrl = "localhost:6379";
            this.RedisUsername = string.Empty;
            this.RedisPassword = string.Empty;
            this.SelectedDatabase = 0;
            this.AllowAdmin = true;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Loads from setting.
        /// </summary>
        /// <param name="redisSetting">The redis setting.</param>
        public void LoadFromSetting(RedisSetting redisSetting)
        {
            this.SettingName = redisSetting.SettingName;
            this.RedisUrl = redisSetting.RedisUrl;
            this.RedisUsername = redisSetting.RedisUsername;
            this.RedisPassword = redisSetting.RedisPassword;
            this.SelectedDatabase = redisSetting.SelectedDatabase;
            this.AllowAdmin = redisSetting.AllowAdmin;
        }
    }
}