using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Server.Application.Command;
using RedisKeyTool.Server.Application.Utils;
using RedisKeyTool.Shared;
using StackExchange.Redis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Server.Application.Handler
{
    /// <summary>
    /// This gets our redis keys
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Server.Application.Command.GetRedisKeys, System.Collections.Generic.List{RedisKeyTool.Shared.KeyListItem}}" />
    public class GetRedisKeysCountHandler : IRequestHandler<GetRedisKeysCount, ApplicationResponse>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GetRedisKeysHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRedisKeysHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public GetRedisKeysCountHandler(ILogger<GetRedisKeysHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        /// <exception cref="RedisException">Not Connected to Redis</exception>
        public Task<ApplicationResponse> Handle(GetRedisKeysCount request, CancellationToken cancellationToken)
        {
            ApplicationResponse applicationResponse;
            ConnectionMultiplexer connectionMultiplexer;
            var redisServer = ConnectionBuilder.BuildConnectToRedisServer(request.RedisSetting, out connectionMultiplexer);

            if (redisServer != null)
            {
                int pageSize = 250;
                RedisValue pattern = default;
                long cursor = 0;
                int pageOffset = 0;

                var keys = redisServer.Keys(request.RedisSetting.SelectedDatabase, pattern, pageSize, cursor, pageOffset, CommandFlags.None);
                applicationResponse = new ApplicationResponse(true, keys.ToList().Count.ToString());
            }
            else
            {
                _logger.LogError("Not Connected to Redis");
                applicationResponse = new ApplicationResponse(false, "Not Connected to Redis");
                throw new RedisException("Not Connected to Redis");
            }

            connectionMultiplexer.Close();
            connectionMultiplexer.Dispose();

            return Task.FromResult(applicationResponse);
        }
    }
}