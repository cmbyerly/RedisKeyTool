using System.Collections.Generic;

namespace RedisKeyTool.Shared
{
    /// <summary>
    /// Database Response
    /// </summary>
    public class DatabaseConfigResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResponse"/> class.
        /// </summary>
        public DatabaseConfigResponse() 
        {
            IsSuccess = true;
            Message = string.Empty;
            FeatureList = new List<string>();
            ConfigItems = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseResponse"/> class.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="message">The message.</param>
        public DatabaseConfigResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
            FeatureList = new List<string>();
            ConfigItems = new List<string>();
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the feature list.
        /// </summary>
        /// <value>
        /// The feature list.
        /// </value>
        public List<string> FeatureList { get; set; }

        /// <summary>
        /// Gets or sets the configuration items.
        /// </summary>
        /// <value>
        /// The configuration items.
        /// </value>
        public List<string> ConfigItems { get; set; }

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