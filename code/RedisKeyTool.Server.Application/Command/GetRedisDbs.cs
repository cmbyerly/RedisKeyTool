using MediatR;
using RedisKeyTool.Shared;

namespace RedisKeyTool.Application.Command
{
    /// <summary>
    /// Get the redis dbs command
    /// </summary>
    /// <seealso cref="MediatR.IRequest{RedisKeyTool.Shared.DatabaseResponse}" />
    public class GetRedisDbs : IRequest<DatabaseResponse>
    {
        public GetRedisDbs()
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