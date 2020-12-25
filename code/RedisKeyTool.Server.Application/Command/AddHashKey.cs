using MediatR;
using RedisKeyTool.Shared;

namespace RedisKeyTool.Server.Application.Command
{
    /// <summary>
    /// Add a hash key
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RedisKeyTool.Shared.ApplicationResponse}" />
    public class AddHashKey : IRequest<ApplicationResponse>
    {
        public AddHashKey()
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