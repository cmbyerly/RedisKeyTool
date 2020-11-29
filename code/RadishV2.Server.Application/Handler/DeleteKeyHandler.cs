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
    /// Delete Key Handler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RadishV2.Server.Application.Command.DeleteKey, RadishV2.Shared.ApplicationResponse}" />
    public class DeleteKeyHandler : IRequestHandler<DeleteKey, ApplicationResponse>
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public Task<ApplicationResponse> Handle(DeleteKey request, CancellationToken cancellationToken)
        {
            ApplicationResponse response;

            var redisServer = ConnectionBuilder.BuildConnectToRedis(request.KeyPayload.RedisSetting);

            if (redisServer != null)
            {
                var db = redisServer.GetDatabase(request.KeyPayload.RedisSetting.SelectedDatabase);
                foreach (var key in this.GetKeys(redisServer, request.KeyPayload.RedisSetting))
                {
                    if (key.KeyName == request.KeyPayload.KeyListItem.KeyName)
                    {
                        db.KeyDelete(key.KeyName);
                    }
                }

                response = new ApplicationResponse(true, "Deleted Keys");
            }
            else
            {
                response = new ApplicationResponse(false, "Failed to Delete Keys");
            }

            redisServer.Dispose();

            return Task.FromResult(response);
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="redisSetting">The redis setting.</param>
        /// <returns></returns>
        /// <exception cref="RedisException">Not Connected to Redis</exception>
        public List<KeyListItem> GetKeys(ConnectionMultiplexer server, RedisSetting redisSetting)
        {
            var db = server.GetDatabase(redisSetting.SelectedDatabase);
            List<KeyListItem> myKeys = new List<KeyListItem>();
            if (server != null)
            {
                foreach (var key in server.GetServer(redisSetting.RedisUrl).Keys(redisSetting.SelectedDatabase))
                {
                    KeyListItem item = new KeyListItem(key, db.KeyType(key));
                    myKeys.Add(item);
                }
            }
            else
            {
                throw new RedisException("Not Connected to Redis");
            }

            return myKeys;
        }
    }
}