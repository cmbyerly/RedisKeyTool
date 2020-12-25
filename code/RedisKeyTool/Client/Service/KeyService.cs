using RedisKeyTool.Shared;
using System;
using System.Threading.Tasks;

namespace RedisKeyTool.Service
{
    /// <summary>
    /// This is the service for editing keys
    /// </summary>
    public class KeyService
    {
        /// <summary>
        /// Gets or sets the current key.
        /// </summary>
        /// <value>
        /// The current key.
        /// </value>
        public KeyListItem CurrentKey { get; set; }

        /// <summary>
        /// Edits the key.
        /// </summary>
        /// <param name="keyListItem">The key list item.</param>
        public async Task EditKey(KeyListItem keyListItem)
        {
            CurrentKey = keyListItem;

            if (NotifyEditKey != null)
            {
                await NotifyEditKey.Invoke(CurrentKey);
            }
        }

        /// <summary>
        /// Occurs when [notify edit key].
        /// </summary>
        public event Func<KeyListItem, Task> NotifyEditKey;
    }
}