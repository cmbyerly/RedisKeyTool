using System.Collections.Generic;

namespace RedisKeyTool.Shared
{
    /// <summary>
    /// Database Response
    /// </summary>
    public class DatabaseResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResponse"/> class.
        /// </summary>
        public DatabaseResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResponse"/> class.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="message">The message.</param>
        public DatabaseResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResponse"/> class.
        /// </summary>
        /// <param name="dbListItems">The database list items.</param>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="message">The message.</param>
        public DatabaseResponse(List<DbListItem> dbListItems, bool isSuccess, string message)
        {
            DbListItems = dbListItems;
            IsSuccess = isSuccess;
            Message = message;
        }

        /// <summary>
        /// Gets or sets the database list items.
        /// </summary>
        /// <value>
        /// The database list items.
        /// </value>
        public List<DbListItem> DbListItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}