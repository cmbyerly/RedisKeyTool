using MediatR;
using RedisKeyTool.Shared;

namespace RedisKeyTool.Application.Command
{
    /// <summary>
    /// Get the redis dbs command
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RedisKeyTool.Shared.DatabaseConfigResponse}" />
    public class GetRedisServerInfo : IRequest<DatabaseConfigResponse>
    {
        public GetRedisServerInfo()
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