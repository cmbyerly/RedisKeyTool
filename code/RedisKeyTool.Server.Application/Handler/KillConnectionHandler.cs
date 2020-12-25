using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Server.Application.Command;
using RedisKeyTool.Server.Application.Utils;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Server.Application.Handler
{
    /// <summary>
    /// This gets our redis keys
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Server.Application.Command.GetRedisKeys, System.Collections.Generic.List{RedisKeyTool.Shared.KeyListItem}}" />
    public class KillConnectionHandler : IRequestHandler<KillConnection, bool>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GetRedisKeysHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRedisKeysHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public KillConnectionHandler(ILogger<GetRedisKeysHandler> logger)
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
        public Task<bool> Handle(KillConnection request, CancellationToken cancellationToken)
        {
            ConnectionMultiplexer connectionMultiplexer;
            var redisServer = ConnectionBuilder.BuildConnectToRedisServer(request.ConnectionKiller, out connectionMultiplexer);

            if (redisServer != null)
            {
                foreach (var client in redisServer.ClientList())
                {
                    if (client.Id == Convert.ToInt64(request.ConnectionKiller.Id))
                    {
                        redisServer.ClientKill(client.Id);
                    }
                }

                connectionMultiplexer.Close();
                connectionMultiplexer.Dispose();
            }
            else
            {
                _logger.LogError("Not Connected to Redis");
                throw new RedisException("Not Connected to Redis");
            }

            return Task.FromResult(true);
        }
    }
}