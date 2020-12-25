using MediatR;
using Microsoft.Extensions.Logging;
using RedisKeyTool.Server.Application.Command;
using RedisKeyTool.Server.Application.Utils;
using RedisKeyTool.Shared;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedisKeyTool.Server.Application.Handler
{
    /// <summary>
    /// Add String Key Handler
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{RedisKeyTool.Server.Application.Command.AddStringKey, RedisKeyTool.Shared.ApplicationResponse}" />
    public class AddStringKeyHandler : IRequestHandler<AddStringKey, ApplicationResponse>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<AddStringKeyHandler> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddStringKeyHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public AddStringKeyHandler(ILogger<AddStringKeyHandler> logger)
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
        public Task<ApplicationResponse> Handle(AddStringKey request, CancellationToken cancellationToken)
        {
            ApplicationResponse response;

            try
            {
                var redisServer = ConnectionBuilder.BuildConnectToRedis(request.KeyPayload.RedisSetting);

                if (redisServer != null)
                {
                    var db = redisServer.GetDatabase(request.KeyPayload.RedisSetting.SelectedDatabase);

                    if (ConnectionBuilder.DoesKeyExist(db, request.KeyPayload.KeyListItem.KeyName))
                    {
                        response = new ApplicationResponse(false, "Key Exists");
                    }
                    else
                    {
                        db.StringSet(request.KeyPayload.KeyListItem.KeyName, request.KeyPayload.KeyListItem.KeyValues[0].Value);

                        response = new ApplicationResponse(true, "Added or Updated Keys");
                    }

                    if (request.KeyPayload.KeyListItem.Expiry != null && request.KeyPayload.KeyListItem.Expiry != "00:00:00")
                    {
                        var expTime = TimeSpan.Parse(request.KeyPayload.KeyListItem.Expiry);
                        db.KeyExpire(request.KeyPayload.KeyListItem.KeyName, expTime);
                    }
                    else
                    {
                        var expiry = db.KeyTimeToLive(request.KeyPayload.KeyListItem.KeyName);
                        if (expiry != null)
                        {
                            TimeSpan? timeSpan = null;
                            db.KeyExpire(request.KeyPayload.KeyListItem.KeyName, timeSpan);
                        }
                    }
                }
                else
                {
                    response = new ApplicationResponse(true, "Failed to Add or Update Keys");
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
    }
}