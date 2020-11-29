using RadishV2.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RadishV2.Service
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
            this.RedisSetting = new RedisSetting();
            this.KeyList = new List<KeyListItem>();
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
        /// Updates this instance.
        /// </summary>
        public async Task Update()
        {
            if (Notify != null)
            {
                await Notify.Invoke(true);
            }
        }

        /// <summary>
        /// Occurs when [notify].
        /// </summary>
        public event Func<bool, Task> Notify;
    }
}