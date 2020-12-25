namespace RedisKeyTool.Shared
{
    /// <summary>
    /// Application Response
    /// </summary>
    public class ApplicationResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResponse"/> class.
        /// </summary>
        public ApplicationResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResponse"/> class.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        public ApplicationResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationResponse"/> class.
        /// </summary>
        /// <param name="isSuccess">if set to <c>true</c> [is success].</param>
        /// <param name="message">The message.</param>
        public ApplicationResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

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