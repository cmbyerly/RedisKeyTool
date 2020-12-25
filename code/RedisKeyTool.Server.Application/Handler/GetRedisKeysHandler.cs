using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Server.Application.Command;
using RedisKeyTool.Server.Application.Utils;
using RedisKeyTool.Shared;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Server.Application.Handler
{
    /// <summary>
    /// This gets our redis keys
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Server.Application.Command.GetRedisKeys, System.Collections.Generic.List{RedisKeyTool.Shared.KeyListItem}}" />
    public class GetRedisKeysHandler : IRequestHandler<GetRedisKeys, List<KeyListItem>>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GetRedisKeysHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRedisKeysHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public GetRedisKeysHandler(ILogger<GetRedisKeysHandler> logger)
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
        public Task<List<KeyListItem>> Handle(GetRedisKeys request, CancellationToken cancellationToken)
        {
            ConnectionMultiplexer connectionMultiplexer;
            var redisServer = ConnectionBuilder.BuildConnectToRedisServer(request.RedisSetting, out connectionMultiplexer);
            var db = connectionMultiplexer.GetDatabase(request.RedisSetting.SelectedDatabase);

            List<KeyListItem> myKeys = new List<KeyListItem>();
            if (redisServer != null)
            {
                var keys = redisServer.Keys(request.RedisSetting.SelectedDatabase);
                foreach (var key in keys)
                {
                    KeyListItem item = new KeyListItem(key, db.KeyType(key));
                    myKeys.Add(item);
                }
            }
            else
            {
                _logger.LogError("Not Connected to Redis");
                throw new RedisException("Not Connected to Redis");
            }

            connectionMultiplexer.Close();
            connectionMultiplexer.Dispose();

            return Task.FromResult(myKeys);
        }
    }
}