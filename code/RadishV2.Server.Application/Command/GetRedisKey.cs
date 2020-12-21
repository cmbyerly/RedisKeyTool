using MediatR;
using RadishV2.Shared;

namespace RadishV2.Server.Application.Command
{
    /// <summary>
    /// Inflate the redis key
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RadishV2.Shared.KeyListItem}" />
    public class GetRedisKey : IRequest<KeyListItem>
    {
        public GetRedisKey()
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