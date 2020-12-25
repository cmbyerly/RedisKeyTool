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
    /// This inflates the key.  This is due to blazor not handling nested lists especially well.
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Server.Application.Command.GetRedisKey, RedisKeyTool.Shared.KeyListItem}" />
    public class GetRedisKeyHandler : IRequestHandler<GetRedisKey, KeyListItem>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GetRedisKeyHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetRedisKeyHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public GetRedisKeyHandler(ILogger<GetRedisKeyHandler> logger)
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
        public Task<KeyListItem> Handle(GetRedisKey request, CancellationToken cancellationToken)
        {
            var redisServer = ConnectionBuilder.BuildConnectToRedis(request.KeyPayload.RedisSetting);

            KeyListItem myKey = new KeyListItem();

            if (redisServer != null)
            {
                foreach (var key in redisServer.GetServer(request.KeyPayload.RedisSetting.RedisUrl).Keys(request.KeyPayload.RedisSetting.SelectedDatabase))
                {
                    if (key.ToString() == request.KeyPayload.KeyListItem.KeyName)
                    {
                        myKey = this.GetKeyValues(redisServer, request.KeyPayload.RedisSetting.SelectedDatabase, request.KeyPayload.KeyListItem.KeyName);
                    }
                }
            }
            else
            {
                _logger.LogError("Not Connected to Redis");
                throw new RedisException("Not Connected to Redis");
            }

            redisServer.Close();
            redisServer.Dispose();

            return Task.FromResult(myKey);
        }

        /// <summary>
        /// Gets the key values.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="dbNumber">The database number.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="RedisException">Not Connected to Redis</exception>
        public KeyListItem GetKeyValues(ConnectionMultiplexer server, int dbNumber, string key)
        {
            List<KeyValue> values = new List<KeyValue>();

            KeyListItem retval;
            if (server != null)
            {
                var db = server.GetDatabase(dbNumber);

                if (db.KeyExists(key))
                {
                    switch (db.KeyType(key))
                    {
                        case RedisType.Hash:
                            foreach (var hashVal in db.HashGetAll(key))
                            {
                                values.Add(new KeyValue(hashVal.Name, hashVal.Value));
                            }
                            values = values.OrderBy(x => x.Name).ToList();
                            break;

                        case RedisType.List:
                            foreach (var listVal in db.ListRange(key))
                            {
                                values.Add(new KeyValue(listVal.ToString()));
                            }
                            break;

                        case RedisType.Set:
                            foreach (var setVal in db.SetMembers(key))
                            {
                                values.Add(new KeyValue(setVal.ToString()));
                            }
                            break;

                        case RedisType.SortedSet:
                            foreach (var setVal in db.SortedSetRangeByRankWithScores(key))
                            {
                                values.Add(new KeyValue(setVal.Element.ToString(), setVal.Score));
                            }
                            break;

                        case RedisType.String:
                            values.Add(new KeyValue(db.StringGet(key)));
                            break;

                        default:
                            break;
                    }
                }

                var expiry = db.KeyTimeToLive(key);
                retval = new KeyListItem(key, values, false, db.KeyType(key), expiry);
            }
            else
            {
                _logger.LogError("Not Connected to Redis");
                throw new RedisException("Not Connected to Redis");
            }

            return retval;
        }
    }
}