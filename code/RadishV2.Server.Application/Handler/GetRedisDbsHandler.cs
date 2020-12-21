using MediatR;
using Microsoft.Extensions.Logging;
using RadishV2.Application.Command;
using RadishV2.Server.Application.Utils;
using RadishV2.Shared;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RadishV2.Application.Handler
{
    /// <summary>
    /// GetRedisDbsHandler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RadishV2.Application.Command.GetRedisDbs, System.Collections.Generic.IEnumerable{RadishV2.Entities.DbListItem}}" />
    public class GetRedisDbsHandler : IRequestHandler<GetRedisDbs, DatabaseResponse>
    {
        private readonly ILogger<GetRedisDbsHandler> _logger;

        public GetRedisDbsHandler(ILogger<GetRedisDbsHandler> logger)
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
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<DatabaseResponse> Handle(GetRedisDbs request, CancellationToken cancellationToken)
        {
            DatabaseResponse databaseResponse = new DatabaseResponse();

            try
            {
                var redisServer = ConnectionBuilder.BuildConnectToRedis(request.RedisSetting);

                List<DbListItem> retval = new List<DbListItem>();

                for (int i = 0; i < redisServer.GetServer(request.RedisSetting.RedisUrl).DatabaseCount; i++)
                {
                    DbListItem tItem = new DbListItem(i);
                    retval.Add(tItem);
                }

                databaseResponse = new DatabaseResponse(retval, true, "Connected");

                redisServer.Close();
                redisServer.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                databaseResponse = new DatabaseResponse(false, ex.Message);
            }

            return Task.FromResult(databaseResponse);
        }
    }
}