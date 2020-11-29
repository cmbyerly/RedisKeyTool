using MediatR;
using RadishV2.Server.Application.Command;
using RadishV2.Server.Application.Utils;
using RadishV2.Shared;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RadishV2.Server.Application.Handler
{
    /// <summary>
    /// This gets our redis keys
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RadishV2.Server.Application.Command.GetRedisKeys, System.Collections.Generic.List{RadishV2.Shared.KeyListItem}}" />
    public class GetRedisKeysHandler : IRequestHandler<GetRedisKeys, List<KeyListItem>>
    {
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
            var redisServer = ConnectionBuilder.BuildConnectToRedis(request.RedisSetting);

            var db = redisServer.GetDatabase(request.RedisSetting.SelectedDatabase);
            List<KeyListItem> myKeys = new List<KeyListItem>();
            if (redisServer != null)
            {
                foreach (var key in redisServer.GetServer(request.RedisSetting.RedisUrl).Keys(request.RedisSetting.SelectedDatabase))
                {
                    KeyListItem item = new KeyListItem(key, db.KeyType(key));
                    myKeys.Add(item);
                }
            }
            else
            {
                throw new RedisException("Not Connected to Redis");
            }

            redisServer.Dispose();

            return Task.FromResult(myKeys);
        }
    }
}