using RedisKeyTool.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedisKeyTool.Service
{
    /// <summary>
    /// This is our setting service to store the redis stuff.
    /// </summary>
    public class SettingService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingService"/> class.
        /// </summary>
        public SettingService()
        {
            RedisSetting = new RedisSetting();
            KeyList = new List<KeyListItem>();
            IsLoggedIn = false;
        }

        /// <summary>
        /// Gets or sets the redis setting.
        /// </summary>
        /// <value>
        /// The redis setting.
        /// </value>
        public RedisSetting RedisSetting { get; set; }

        /// <summary>
        /// Gets or sets the key list.
        /// </summary>
        /// <value>
        /// The key list.
        /// </value>
        public List<KeyListItem> KeyList { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is logged in.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is logged in; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoggedIn { get; set; }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public async Task Update(bool isLoggedIn)
        {
            IsLoggedIn = isLoggedIn;

            if (Notify != null)
            {
                await Notify.Invoke(isLoggedIn);
            }
        }

        /// <summary>
        /// Occurs when [notify].
        /// </summary>
        public event Func<bool, Task> Notify;
    }
}