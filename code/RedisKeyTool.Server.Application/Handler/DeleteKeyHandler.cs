using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Server.Application.Command;
using RedisKeyTool.Server.Application.Utils;
using RedisKeyTool.Shared;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Server.Application.Handler
{
    /// <summary>
    /// Delete Key Handler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Server.Application.Command.DeleteKey, RedisKeyTool.Shared.ApplicationResponse}" />
    public class DeleteKeyHandler : IRequestHandler<DeleteKey, ApplicationResponse>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DeleteKeyHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteKeyHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public DeleteKeyHandler(ILogger<DeleteKeyHandler> logger)
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
        public Task<ApplicationResponse> Handle(DeleteKey request, CancellationToken cancellationToken)
        {
            ApplicationResponse response;

            try
            {
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

                redisServer.Close();
                redisServer.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response = new ApplicationResponse(false, ex.Message);
            }

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
                _logger.LogError("Not Connected to Redis");
                throw new RedisException("Not Connected to Redis");
            }

            return myKeys;
        }
    }
}