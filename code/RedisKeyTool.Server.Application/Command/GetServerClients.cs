using MediatR;
using RedisKeyTool.Shared;
using System.Collections.Generic;

namespace RedisKeyTool.Server.Application.Command
{
    /// <summary>
    /// Get the redis keys command
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{RedisKeyTool.Shared.KeyListItem}}" />
    public class GetServerClients : IRequest<List<ClientListItem>>
    {
        public GetServerClients()
        {
        }

        /// <summary>
        /// Gets or sets the redis setting.
        /// </summary>
        /// <value>
        /// The redis setting.
        /// </value>
        public RedisSetting RedisSetting { get; set; }
    }
}