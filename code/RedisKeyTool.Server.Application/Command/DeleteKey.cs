using MediatR;
using RedisKeyTool.Shared;

namespace RedisKeyTool.Server.Application.Command
{
    /// <summary>
    /// Delete Key
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RedisKeyTool.Shared.ApplicationResponse}" />
    public class DeleteKey : IRequest<ApplicationResponse>
    {
        public DeleteKey()
        {
        }

        /// <summary>
        /// Gets or sets the key payload.
        /// </summary>
        /// <value>
        /// The key payload.
        /// </value>
        public KeyPayload KeyPayload { get; set; }
    }
}