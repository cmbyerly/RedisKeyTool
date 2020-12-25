using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Server.Application.Command;
using RedisKeyTool.Server.Application.Utils;
using RedisKeyTool.Shared;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Server.Application.Handler
{
    /// <summary>
    /// This gets our redis keys
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Server.Application.Command.GetRedisKeys, System.Collections.Generic.List{RedisKeyTool.Shared.KeyListItem}}" />
    public class GetServerClientsHandler : IRequestHandler<GetServerClients, List<ClientListItem>>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GetRedisKeysHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRedisKeysHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public GetServerClientsHandler(ILogger<GetRedisKeysHandler> logger)
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
        public Task<List<ClientListItem>> Handle(GetServerClients request, CancellationToken cancellationToken)
        {
            ConnectionMultiplexer connectionMultiplexer;
            var redisServer = ConnectionBuilder.BuildConnectToRedisServer(request.RedisSetting, out connectionMultiplexer);

            List<ClientListItem> myClients = new List<ClientListItem>();
            if (redisServer != null)
            {
                foreach (var client in redisServer.ClientList())
                {
                    ClientListItem item = new ClientListItem();
                    item.Id = client.Id.ToString();
                    item.Host = client.Host;
                    item.Address = client.Address.ToString();
                    item.AgeSeconds = client.AgeSeconds.ToString();
                    item.Database = client.Database.ToString();
                    item.FlagsRaw = client.FlagsRaw;
                    item.IdleSeconds = client.IdleSeconds.ToString();
                    item.LastCommand = client.LastCommand;
                    item.Name = client.Name;
                    item.PatternSubscriptionCount = client.PatternSubscriptionCount.ToString();
                    item.Port = client.Port.ToString();
                    item.Raw = client.Raw;
                    item.SubscriptionCount = client.SubscriptionCount.ToString();
                    item.TransactionCommandLength = client.TransactionCommandLength.ToString();

                    myClients.Add(item);
                }

                myClients = myClients.OrderBy(x => x.Name).ToList();

                connectionMultiplexer.Close();
                connectionMultiplexer.Dispose();
            }
            else
            {
                _logger.LogError("Not Connected to Redis");
                throw new RedisException("Not Connected to Redis");
            }

            return Task.FromResult(myClients);
        }
    }
}